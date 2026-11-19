using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

/// <summary>Listens for Windows-key presses on the current interactive desktop.</summary>
public sealed class KeyboardHook : IDisposable
{
    private const int WH_KEYBOARD_LL = 13;
    private const int WM_KEYDOWN = 0x0100;
    private const int WM_KEYUP = 0x0101;
    private const int WM_SYSKEYDOWN = 0x0104;
    private const int WM_SYSKEYUP = 0x0105;
    private const int VK_LWIN = 0x5B;
    private const int VK_RWIN = 0x5C;

    [StructLayout(LayoutKind.Sequential)]
    private struct KeyboardHookData
    {
        public uint VirtualKeyCode;
        public uint ScanCode;
        public uint Flags;
        public uint Time;
        public UIntPtr ExtraInfo;
    }

    private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll", EntryPoint = "SetWindowsHookExW", SetLastError = true)]
    private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc callback, IntPtr module, uint threadId);

    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool UnhookWindowsHookEx(IntPtr hook);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern IntPtr CallNextHookEx(IntPtr hook, int code, IntPtr wParam, IntPtr lParam);

    [DllImport("kernel32.dll", EntryPoint = "GetModuleHandleW", CharSet = CharSet.Unicode, SetLastError = true)]
    private static extern IntPtr GetModuleHandle(string? moduleName);

    private readonly LowLevelKeyboardProc _callback;
    private IntPtr _hookId;
    private bool _leftWindowsKeyDown;
    private bool _rightWindowsKeyDown;
    private bool _disposed;

    public event EventHandler? WindowsKeyPressed;

    public KeyboardHook() => _callback = HookProcedure;

    /// <summary>
    /// Installs the hook. Call this on a UI thread that has a running message loop.
    /// Calling it more than once is safe.
    /// </summary>
    public void HookKeyboard()
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
        if (_hookId != IntPtr.Zero)
            return;

        var module = GetModuleHandle(null);
        _hookId = SetWindowsHookEx(WH_KEYBOARD_LL, _callback, module, 0);
        if (_hookId == IntPtr.Zero)
            throw new Win32Exception(Marshal.GetLastWin32Error(), "Could not install the low-level keyboard hook.");
    }

    public void UnhookKeyboard()
    {
        if (_hookId == IntPtr.Zero)
            return;

        var hook = _hookId;
        _hookId = IntPtr.Zero;
        if (!UnhookWindowsHookEx(hook))
            throw new Win32Exception(Marshal.GetLastWin32Error(), "Could not remove the low-level keyboard hook.");

        _leftWindowsKeyDown = false;
        _rightWindowsKeyDown = false;
    }

    private IntPtr HookProcedure(int code, IntPtr wParam, IntPtr lParam)
    {
        if (code >= 0)
        {
            var message = unchecked((int)wParam.ToInt64());
            if (message is WM_KEYDOWN or WM_SYSKEYDOWN or WM_KEYUP or WM_SYSKEYUP)
            {
                var data = Marshal.PtrToStructure<KeyboardHookData>(lParam);
                if (data.VirtualKeyCode == VK_LWIN || data.VirtualKeyCode == VK_RWIN)
                {
                    var isDown = message is WM_KEYDOWN or WM_SYSKEYDOWN;
                    ref bool keyIsDown = ref (data.VirtualKeyCode == VK_LWIN
                        ? ref _leftWindowsKeyDown
                        : ref _rightWindowsKeyDown);

                    if (isDown)
                    {
                        if (!keyIsDown)
                        {
                            keyIsDown = true;
                            try
                            {
                                WindowsKeyPressed?.Invoke(this, EventArgs.Empty);
                            }
                            catch
                            {
                                // Exceptions must not escape through the native hook callback.
                            }
                        }
                    }
                    else
                    {
                        keyIsDown = false;
                    }

                    // Suppress both key down and key up so the Start menu does not open.
                    return new IntPtr(1);
                }
            }
        }

        return CallNextHookEx(_hookId, code, wParam, lParam);
    }

    public void Dispose()
    {
        if (_disposed)
            return;
        UnhookKeyboard();
        _disposed = true;
        GC.SuppressFinalize(this);
    }
}


