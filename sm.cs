using Microsoft.Win32;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinRT;
using static Traductor;

namespace deneOS
{
    public partial class sm : Form
    {
        public sm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;

            Color bgColor = globaldata.isImageLoaded ? ColorTranslator.FromHtml(globaldata.wallpaperPredominantColorHex) : Color.Black;
            if (bgColor.GetBrightness() > 0.6f)
            {
                bgColor = Color.FromArgb(
                    (int)(bgColor.R * 0.4f),
                    (int)(bgColor.G * 0.4f),
                    (int)(bgColor.B * 0.4f)
                );
            }
            this.BackColor = bgColor;
            this.ForeColor = Color.White;
            BasePanel.BackColor = bgColor;
            BasePanel.BringToFront();

            // --- Escalado HiDPI ---
            // El diseñador usa AutoScaleMode.None y todo está en píxeles pensados para 100 %
            // (378x513). Las fuentes ya se escalan solas (están en puntos), pero las
            // dimensiones de paneles, iconos y botones no: por eso el menú se veía pequeño.
            // Escalamos la geometría una sola vez, usando el DPI del monitor de la taskbar.
            // NO tocar las fuentes aquí, o se duplicaría su escala.
            const int baseWidth = 378;
            const int baseHeight = 513;

            var taskbar = Application.OpenForms.OfType<tbar>().FirstOrDefault();
            var screen = taskbar != null
                ? Screen.FromControl(taskbar)
                : Screen.PrimaryScreen ?? Screen.AllScreens.FirstOrDefault();
            var screenBounds = screen?.Bounds ?? new Rectangle(0, 0, 1920, 1080);
            int taskbarTop = taskbar?.Top ?? screenBounds.Bottom;

            float scale = (taskbar?.DeviceDpi ?? this.DeviceDpi) / 96f;

            // Seguro: si a este factor el menú no cabe encima de la taskbar, se reduce
            // lo justo para que siempre quede completo y visible.
            int availableHeight = taskbarTop - screenBounds.Top;
            if (baseHeight * scale > availableHeight)
                scale = Math.Max(1f, availableHeight / (float)baseHeight);

            if (Math.Abs(scale - 1f) > 0.01f)
                this.Scale(new SizeF(scale, scale));

            this.Size = new Size(
                (int)Math.Round(baseWidth * scale),
                (int)Math.Round(baseHeight * scale));

            int formWidth = this.Size.Width;
            int formHeight = this.Size.Height;
            int x = taskbar?.Left ?? screenBounds.Left;
            int y = taskbarTop - formHeight;
            int maxX = screenBounds.Right - formWidth;
            int maxY = screenBounds.Bottom - formHeight;

            if (x < screenBounds.Left) x = screenBounds.Left;
            if (x > maxX) x = maxX;
            if (y < screenBounds.Top) y = screenBounds.Top;
            if (y > maxY) y = maxY;
            this.Location = new Point(x, y);

            /*var Day = DateTime.Now.Day;
            switch (Day)
            {
                //for each case (day) set to calendarPic the resource with format [c]+[day]
                case 1:
                    calendarPic.Image = Properties.Resources.c1;
                    break;
                case 2:
                    calendarPic.Image = Properties.Resources.c2;
                    break;
                case 3:
                    calendarPic.Image = Properties.Resources.c3;
                    break;
                case 4:
                    calendarPic.Image = Properties.Resources.c4;
                    break;
                case 5:
                    calendarPic.Image = Properties.Resources.c5;
                    break;
                case 6:
                    calendarPic.Image = Properties.Resources.c6;
                    break;
                case 7:
                    calendarPic.Image = Properties.Resources.c7;
                    break;
                case 8:
                    calendarPic.Image = Properties.Resources.c8;
                    break;
                case 9:
                    calendarPic.Image = Properties.Resources.c9;
                    break;
                case 10:
                    calendarPic.Image = Properties.Resources.c10;
                    break;
                case 11:
                    calendarPic.Image = Properties.Resources.c11;
                    break;
                case 12:
                    calendarPic.Image = Properties.Resources.c12;
                    break;
                case 13:
                    calendarPic.Image = Properties.Resources.c13;
                    break;
                case 14:
                    calendarPic.Image = Properties.Resources.c14;
                    break;
                case 15:
                    calendarPic.Image = Properties.Resources.c15;
                    break;
                case 16:
                    calendarPic.Image = Properties.Resources.c16;
                    break;
                case 17:
                    calendarPic.Image = Properties.Resources.c17;
                    break;
                case 18:
                    calendarPic.Image = Properties.Resources.c18;
                    break;
                case 19:
                    calendarPic.Image = Properties.Resources.c19;
                    break;
                case 20:
                    calendarPic.Image = Properties.Resources.c20;
                    break;
                case 21:
                    calendarPic.Image = Properties.Resources.c21;
                    break;
                case 22:
                    calendarPic.Image = Properties.Resources.c22;
                    break;
                case 23:
                    calendarPic.Image = Properties.Resources.c23;
                    break;
                case 24:
                    calendarPic.Image = Properties.Resources.c24;
                    break;
                case 25:
                    calendarPic.Image = Properties.Resources.c25;
                    break;
                case 26:
                    calendarPic.Image = Properties.Resources.c26;
                    break;
                case 27:
                    calendarPic.Image = Properties.Resources.c27;
                    break;
                case 28:
                    calendarPic.Image = Properties.Resources.c28;
                    break;
                case 29:
                    calendarPic.Image = Properties.Resources.c29;
                    break;
                case 30:
                    calendarPic.Image = Properties.Resources.c30;
                    break;
                case 31:
                    calendarPic.Image = Properties.Resources.c31;
                    break;
                default:
                    calendarPic.Image = Properties.Resources.ScheduleTime_80;
                    break;
            }
            */
            this.TopMost = true;


            var rawData = StartMenuReg.GetRegData();
            var arraysData = rawData.Item1;
            var showR2WButton = rawData.Item2;

            dockrightR2Wbtn.Visible = showR2WButton == 1 ? true : false;

            string[] categories = arraysData[0];
            string[] paths = arraysData[1];

            App0Category.Text = (string)T(categories[0]);
            App1Category.Text = (string)T(categories[1]);
            App2Category.Text = (string)T(categories[2]);
            App3Category.Text = (string)T(categories[3]);
            App4Category.Text = (string)T(categories[4]);
            App5Category.Text = (string)T(categories[5]);
            App6Category.Text = (string)T(categories[6]);
            App7Category.Text = (string)T(categories[7]);

            App0Icon.Image = System.Drawing.Icon.ExtractAssociatedIcon(paths[0]).ToBitmap();
            App1Icon.Image = System.Drawing.Icon.ExtractAssociatedIcon(paths[1]).ToBitmap();
            App2Icon.Image = System.Drawing.Icon.ExtractAssociatedIcon(paths[2]).ToBitmap();
            App3Icon.Image = System.Drawing.Icon.ExtractAssociatedIcon(paths[3]).ToBitmap();
            App4Icon.Image = System.Drawing.Icon.ExtractAssociatedIcon(paths[4]).ToBitmap();
            App5Icon.Image = System.Drawing.Icon.ExtractAssociatedIcon(paths[5]).ToBitmap();
            App6Icon.Image = System.Drawing.Icon.ExtractAssociatedIcon(paths[6]).ToBitmap();
            App7Icon.Image = System.Drawing.Icon.ExtractAssociatedIcon(paths[7]).ToBitmap();

            App0Name.Text = Path.GetFileNameWithoutExtension(paths[0]);
            App1Name.Text = Path.GetFileNameWithoutExtension(paths[1]);
            App2Name.Text = Path.GetFileNameWithoutExtension(paths[2]);
            App3Name.Text = Path.GetFileNameWithoutExtension(paths[3]);
            App4Name.Text = Path.GetFileNameWithoutExtension(paths[4]);
            App5Name.Text = Path.GetFileNameWithoutExtension(paths[5]);
            App6Name.Text = Path.GetFileNameWithoutExtension(paths[6]);
            App7Name.Text = Path.GetFileNameWithoutExtension(paths[7]);

            App0Pnl.Click += (s, e) => Process.Start(paths[0]);
            App1Pnl.Click += (s, e) => Process.Start(paths[1]);
            App2Pnl.Click += (s, e) => Process.Start(paths[2]);
            App3Pnl.Click += (s, e) => Process.Start(paths[3]);
            App4Pnl.Click += (s, e) => Process.Start(paths[4]);
            App5Pnl.Click += (s, e) => Process.Start(paths[5]);
            App6Pnl.Click += (s, e) => Process.Start(paths[6]);
            App7Pnl.Click += (s, e) => Process.Start(paths[7]);

            foreach (Control control in App0Pnl.Controls) { control.Click += (s, e) => Process.Start(paths[0]); }
            foreach (Control control in App1Pnl.Controls) { control.Click += (s, e) => Process.Start(paths[1]); }
            foreach (Control control in App2Pnl.Controls) { control.Click += (s, e) => Process.Start(paths[2]); }
            foreach (Control control in App3Pnl.Controls) { control.Click += (s, e) => Process.Start(paths[3]); }
            foreach (Control control in App4Pnl.Controls) { control.Click += (s, e) => Process.Start(paths[4]); }
            foreach (Control control in App5Pnl.Controls) { control.Click += (s, e) => Process.Start(paths[5]); }
            foreach (Control control in App6Pnl.Controls) { control.Click += (s, e) => Process.Start(paths[6]); }
            foreach (Control control in App7Pnl.Controls) { control.Click += (s, e) => Process.Start(paths[7]); }
        }

        class StartMenuReg
        {
            const string SubKeyPath = @"Software\deneOS\startmenu";
            public static (string[][]?, int?) GetRegData()
            {
                using (RegistryKey? key = Registry.CurrentUser.OpenSubKey(SubKeyPath, writable: false))
                {
                    if (key is not null)
                    {
                        // Leer REG_MULTI_SZ -> string[]
                        string[] categories = key.GetValue("EntriesCategories") as string[] ?? [];
                        string[] paths = key.GetValue("EntriesPaths") as string[] ?? [];

                        // Leer REG_DWORD -> int (o bool si lo prefieres)
                        int rawShowButton = Convert.ToInt32(key.GetValue("showR2WButton", 0));
                        bool showR2WButton = rawShowButton != 0;

                        Console.WriteLine($"Categorías: {string.Join(", ", categories)}");
                        Console.WriteLine($"Rutas: {string.Join(", ", paths)}");
                        Console.WriteLine($"showR2WButton: {rawShowButton} ({showR2WButton})");
                        return (new string[][] { categories, paths }, showR2WButton ? 1 : 0);
                    }
                    else
                    {
                        Console.WriteLine("La clave no existe todavía.");
                        return (null, null); // Devolver arrays vacíos si la clave no existe
                    }
                }
            }

        }

        private async void sm_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            for (double i = 0; i <= 0.75; i += 0.05)
            {
                this.Opacity = i;
                await Task.Delay(5);
            }
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\DENEOS\core\deneNavi.exe");
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\DENEOS\\core\\deneNotes.exe");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "explorer.exe",
                UseShellExecute = true,
                WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Windows)
            };

            Process.Start(psi);

            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string a1, b1;
            object c1, d1;
            a1 = (string)T("sdopt");
            b1 = "deneOS";
            c1 = MessageBoxButtons.OKCancel;
            d1 = MessageBoxIcon.Question;
            var a = MessageBox.Show(a1, b1, (MessageBoxButtons)c1, (MessageBoxIcon)d1);

            switch (a)
            {
                case DialogResult.Yes:
                    buttonApagarElegante_Click();
                    break;
                case DialogResult.Cancel:
                    return;
            }
        }
        private async void buttonApagarElegante_Click()
        {
            MessageBox.Show($"{T("syspwoffin")} 15 {T("ss")}...", "deneOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start("shutdown", "-s -t 15");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void sm_Deactivate(object sender, EventArgs e)
        {
            Close();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var run = new Run
            {
                StartPosition = FormStartPosition.Manual
            };

            const int margin = 16;
            var taskbar = Application.OpenForms.OfType<tbar>().FirstOrDefault();
            var screen = taskbar != null
                ? Screen.FromControl(taskbar)
                : Screen.PrimaryScreen ?? Screen.AllScreens.FirstOrDefault();
            var workingArea = screen?.WorkingArea ?? new Rectangle(0, 0, 1920, 1080);

            int taskbarTop = taskbar?.Top ?? workingArea.Bottom;
            int x = (taskbar?.Left ?? workingArea.Left) + margin;
            int y = taskbarTop - run.Height;

            int minX = workingArea.Left + margin;
            int maxX = workingArea.Right - run.Width - margin;
            if (x < minX)
                x = minX;
            else if (x > maxX)
                x = maxX;

            int minY = workingArea.Top + margin;
            if (y < minY)
                y = minY;

            run.Location = new Point(x, y);
            run.Show();
        }
    }
}