using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace deneOS
{
    public partial class Run : Form
    {
        // Import WinAPI functions for sending window messages
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        // Constants for window messages
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;
        object? delegated;
        public Run(object? delegated = null, bool fromShell = false)
        {
            InitializeComponent();
            this.delegated = delegated;

            foreach (Control control in panel1.Controls)
                RegisterDragHandlers(control);

            if (fromShell)
                this.FormClosed += (s, e) => Application.Exit();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                int radius = 25; // Adjust the radius as needed
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(Width - radius, Height - radius, radius, radius, 0, 90);
                path.AddArc(0, Height - radius, radius, radius, 90, 90);
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                this.Region = new Region(path);
                e.Graphics.DrawPath(new Pen(this.BackColor), path);
                e.Graphics.FillPath(new SolidBrush(this.BackColor), path);
            }
        }

        private void RegisterDragHandlers(Control control)
        {
            if (control is not Button)
                control.MouseDown += panel1_MouseDown;

            foreach (Control child in control.Controls)
                RegisterDragHandlers(child);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        void Launch(bool close = false)
        {
            try
            {
                string path = textBox1.Text.Trim();

                if (string.IsNullOrWhiteSpace(path))
                    return;

                if (!File.Exists(path))
                {
                    MessageBox.Show("File does not exist.");
                    return;
                }

                Process.Start(new ProcessStartInfo
                {
                    FileName = path,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting process: {ex.Message}");
            }
            finally { if (close) Close(); }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (delegated != null)
            {
                if (delegated is Form form)
                {
                    form.Invoke(new Action(() => Launch(true)));
                }
            }
            else
            {
                try
                {
                    Hide();

                    using (Process process = Process.Start(
                        new ProcessStartInfo(textBox1.Text)
                        {
                            UseShellExecute = true
                        }))
                    {
                        process?.WaitForExit();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Close();
                }
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Release mouse capture and send message to move window
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
    }
}