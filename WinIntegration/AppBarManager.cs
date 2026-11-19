using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public static class AppBarManager
{
    private const uint ABM_NEW = 0x00000000;
    private const uint ABM_REMOVE = 0x00000001;
    private const uint ABM_QUERYPOS = 0x00000002;
    private const uint ABM_SETPOS = 0x00000003;
    private const int ABN_POSCHANGED = 0x00000001;
    private const int WM_APP = 0x8000;
    private const int WM_DISPLAYCHANGE = 0x007E;
    private const int CallbackMessage = WM_APP + 0x31;

    public enum AppBarEdge
    {
        Left = 0,
        Top = 1,
        Right = 2,
        Bottom = 3,
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct AppBarData
    {
        public uint cbSize;
        public IntPtr hWnd;
        public uint uCallbackMessage;
        public AppBarEdge uEdge;
        public Rect rc;
        public IntPtr lParam;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct Rect
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }

    [DllImport("shell32.dll", SetLastError = true)]
    private static extern UIntPtr SHAppBarMessage(uint dwMessage, ref AppBarData data);

    private sealed class Registration
    {
        public required Form Form { get; init; }
        public required AppBarEdge Edge { get; set; }
        public required int Thickness { get; set; }
        public IntPtr Handle { get; set; }
        public bool IsRegisteredWithShell { get; set; }
        public bool IsPositioning { get; set; }
        public AppBarWindow? Window { get; set; }
    }

    private sealed class AppBarWindow : NativeWindow
    {
        private readonly Registration _registration;

        public AppBarWindow(Registration registration) => _registration = registration;

        public void Attach(IntPtr handle)
        {
            if (Handle == handle)
                return;
            if (Handle != IntPtr.Zero)
                ReleaseHandle();
            AssignHandle(handle);
        }

        public void Detach()
        {
            if (Handle != IntPtr.Zero)
                ReleaseHandle();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == CallbackMessage && m.LParam.ToInt32() == ABN_POSCHANGED)
            {
                Reposition(_registration);
            }
            else if (m.Msg == WM_DISPLAYCHANGE)
            {
                Reposition(_registration);
            }

            base.WndProc(ref m);
        }
    }

    private static readonly Dictionary<Form, Registration> Registrations = new();

    public static void Register(Form form, AppBarEdge edge, int thickness)
    {
        ArgumentNullException.ThrowIfNull(form);
        ValidateThickness(thickness);

        if (!form.IsHandleCreated)
            _ = form.Handle;

        if (!Registrations.TryGetValue(form, out var registration))
        {
            registration = new Registration
            {
                Form = form,
                Edge = edge,
                Thickness = thickness,
            };
            // The NativeWindow needs the same registration object for callbacks.
            registration.Window = new AppBarWindow(registration);
            Registrations.Add(form, registration);
            form.HandleCreated += OnHandleCreated;
            form.HandleDestroyed += OnHandleDestroyed;
            form.Disposed += OnFormDisposed;
        }
        else
        {
            registration.Edge = edge;
            registration.Thickness = thickness;
        }

        RegisterHandle(registration, form.Handle);
        Reposition(registration);
    }

    public static void Unregister(Form form)
    {
        ArgumentNullException.ThrowIfNull(form);
        if (!Registrations.TryGetValue(form, out var registration))
            return;

        UnregisterHandle(registration);
        registration.Window?.Detach();
        form.HandleCreated -= OnHandleCreated;
        form.HandleDestroyed -= OnHandleDestroyed;
        form.Disposed -= OnFormDisposed;
        Registrations.Remove(form);
    }

    public static void SetPosition(Form form, AppBarEdge edge, int thickness)
    {
        ArgumentNullException.ThrowIfNull(form);
        ValidateThickness(thickness);

        if (Registrations.TryGetValue(form, out var registration))
        {
            registration.Edge = edge;
            registration.Thickness = thickness;
            Reposition(registration);
            return;
        }

        // Also supports callers that position a bar before registering it.
        if (form.IsHandleCreated)
            form.Bounds = GetFallbackBounds(form, edge, thickness);
    }

    private static void RegisterHandle(Registration registration, IntPtr handle)
    {
        if (handle == IntPtr.Zero || registration.Handle == handle && registration.IsRegisteredWithShell)
            return;

        UnregisterHandle(registration);
        registration.Handle = handle;
        registration.Window?.Attach(handle);

        var data = CreateData(registration, handle);
        data.uCallbackMessage = CallbackMessage;
        try
        {
            registration.IsRegisteredWithShell = SHAppBarMessage(ABM_NEW, ref data) != UIntPtr.Zero;
        }
        catch (DllNotFoundException)
        {
            registration.IsRegisteredWithShell = false;
        }
        catch (EntryPointNotFoundException)
        {
            registration.IsRegisteredWithShell = false;
        }
    }

    private static void UnregisterHandle(Registration registration)
    {
        if (registration.Handle != IntPtr.Zero && registration.IsRegisteredWithShell)
        {
            var data = CreateData(registration, registration.Handle);
            try
            {
                SHAppBarMessage(ABM_REMOVE, ref data);
            }
            catch (DllNotFoundException) { }
            catch (EntryPointNotFoundException) { }
        }

        registration.IsRegisteredWithShell = false;
        registration.Handle = IntPtr.Zero;
    }

    private static void Reposition(Registration registration)
    {
        if (registration.IsPositioning || registration.Form.IsDisposed || !registration.Form.IsHandleCreated)
            return;

        registration.IsPositioning = true;
        try
        {
            var form = registration.Form;
            var screen = Screen.FromHandle(form.Handle);
            var bounds = screen.Bounds;
            var rect = new Rect
            {
                left = bounds.Left,
                top = bounds.Top,
                right = bounds.Right,
                bottom = bounds.Bottom
            };

            if (registration.IsRegisteredWithShell)
            {
                var query = CreateData(registration, form.Handle);
                query.rc = rect;
                try
                {
                    SHAppBarMessage(ABM_QUERYPOS, ref query);
                    rect = query.rc;
                }
                catch (DllNotFoundException)
                {
                    registration.IsRegisteredWithShell = false;
                }
                catch (EntryPointNotFoundException)
                {
                    registration.IsRegisteredWithShell = false;
                }
            }

            SetEdge(ref rect, registration.Edge, registration.Thickness);
            if (registration.IsRegisteredWithShell)
            {
                var set = CreateData(registration, form.Handle);
                set.rc = rect;
                try
                {
                    SHAppBarMessage(ABM_SETPOS, ref set);
                    rect = set.rc;
                }
                catch (DllNotFoundException)
                {
                    registration.IsRegisteredWithShell = false;
                }
                catch (EntryPointNotFoundException)
                {
                    registration.IsRegisteredWithShell = false;
                }
            }

            form.Bounds = ToRectangle(rect);
        }
        finally
        {
            registration.IsPositioning = false;
        }
    }

    private static AppBarData CreateData(Registration registration, IntPtr handle) => new()
    {
        cbSize = (uint)Marshal.SizeOf<AppBarData>(),
        hWnd = handle,
        uCallbackMessage = CallbackMessage,
        uEdge = registration.Edge
    };

    private static void SetEdge(ref Rect rect, AppBarEdge edge, int thickness)
    {
        switch (edge)
        {
            case AppBarEdge.Left:
                rect.right = rect.left + thickness;
                break;
            case AppBarEdge.Top:
                rect.bottom = rect.top + thickness;
                break;
            case AppBarEdge.Right:
                rect.left = rect.right - thickness;
                break;
            case AppBarEdge.Bottom:
                rect.top = rect.bottom - thickness;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(edge));
        }
    }

    private static Rectangle GetFallbackBounds(Form form, AppBarEdge edge, int thickness)
    {
        var bounds = Screen.FromHandle(form.Handle).Bounds;
        var rect = new Rect { left = bounds.Left, top = bounds.Top, right = bounds.Right, bottom = bounds.Bottom };
        SetEdge(ref rect, edge, thickness);
        return ToRectangle(rect);
    }

    private static Rectangle ToRectangle(Rect rect) =>
        Rectangle.FromLTRB(rect.left, rect.top, rect.right, rect.bottom);

    private static void ValidateThickness(int thickness)
    {
        if (thickness <= 0)
            throw new ArgumentOutOfRangeException(nameof(thickness), "Appbar thickness must be greater than zero.");
    }

    private static void OnHandleCreated(object? sender, EventArgs e)
    {
        if (sender is Form form && Registrations.TryGetValue(form, out var registration))
        {
            RegisterHandle(registration, form.Handle);
            Reposition(registration);
        }
    }

    private static void OnHandleDestroyed(object? sender, EventArgs e)
    {
        if (sender is Form form && Registrations.TryGetValue(form, out var registration))
        {
            UnregisterHandle(registration);
            registration.Window?.Detach();
        }
    }

    private static void OnFormDisposed(object? sender, EventArgs e)
    {
        if (sender is Form form)
            Unregister(form);
    }
}


