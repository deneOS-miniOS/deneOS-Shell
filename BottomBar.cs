using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace deneOS
{
    public partial class BottomBar : Form
    {
        public BottomBar()
        {
            InitializeComponent();
            TopMost = true;
            Shown += (_, __) =>
            {
                AppBarManager.Register(this, AppBarManager.AppBarEdge.Bottom, 64);
            };
            FormClosing += (_, __) =>
            {
                AppBarManager.Unregister(this);
            };
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AppBarManager.SetPosition(this, AppBarManager.AppBarEdge.Bottom, 64);
        }

        private void BottomBar_Load(object sender, EventArgs e)
        {
            var _bottomBarHeight = 64;

            var primaryScreen = Screen.PrimaryScreen
    ?? Screen.AllScreens.FirstOrDefault();

            int screenWidth = primaryScreen?.Bounds.Width ?? 1920;
            int screenHeight = primaryScreen?.Bounds.Height ?? 1080;

            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.Size = new Size(screenWidth, _bottomBarHeight);
            this.Location = new Point(
                0,
                screenHeight - _bottomBarHeight
            );

            this.TopMost = true;
            
            Console.WriteLine("[INFO] Bottom bar configured at the bottom of the screen.");

            Console.WriteLine(
    $"[{GetType().Name}] " +
    $"Location={Location}, " +
    $"Size={Size}, " +
    $"Bounds={Bounds}, " +
    $"Visible={Visible}, " +
    $"TopMost={TopMost}"
);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var forms = Application.OpenForms;
            foreach (Form form in forms)
            {
                if (form is HomeScreen)
                {
                    form.BringToFront();
                    return;
                }
            }
        }
    }
}
