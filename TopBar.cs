using System.Diagnostics;
using Timer = System.Windows.Forms.Timer;

namespace deneOS
{
    public partial class TopBar : Form
    {
        public TopBar()
        {
            InitializeComponent();
            this.TopMost = true;
            Shown += (_, __) =>
            {
                AppBarManager.Register(this, AppBarManager.AppBarEdge.Top, 48);
            };
            FormClosing += (_, __) =>
            {
                AppBarManager.Unregister(this);
            };
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AppBarManager.SetPosition(this, AppBarManager.AppBarEdge.Top, 48);
        }

        private void tbar_Load(object sender, EventArgs e)
        {
            var screen = Screen.PrimaryScreen
    ?? Screen.AllScreens.FirstOrDefault();

            Console.WriteLine(
                $"[DISPLAY] Resolution: {screen?.Bounds.Width}x{screen?.Bounds.Height}"
            );

            Console.WriteLine(
                $"[DISPLAY] DPI: {tbar.GetDpiScale()}"
            );

            int _topBarHeight = dosu.UI.SystemSizes.GetTaskbarHeight();
            var primaryScreen = Screen.PrimaryScreen
        ?? Screen.AllScreens.FirstOrDefault();

            int screenWidth = primaryScreen?.Bounds.Width ?? 1920;

            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            this.Size = new Size(screenWidth, _topBarHeight);

            this.TopMost = true;

            Timer tim = new Timer();
            tim.Interval = 100;
            tim.Tick += new EventHandler(timer1_Tick);
            tim.Start();


            dosu.UI.Scaling.ScaleForm(this);

            Console.WriteLine(
    $"[{GetType().Name}] " +
    $"Location={Location}, " +
    $"Size={Size}, " +
    $"Bounds={Bounds}, " +
    $"Visible={Visible}, " +
    $"TopMost={TopMost}"
);
        }
        private async void timer1_Tick(object sender, EventArgs e)
        {
            PowerStatus status = SystemInformation.PowerStatus;
            //OBTENER PORCENTAJE BATERÍA
            label19.Text = DateTime.Now.ToString("HH:mm:ss");
            float getBattery = status.BatteryLifePercent * 100;
            ToolTip toolTip = new ToolTip();
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(label22, !flagMgmt.MockBattery ? $"{getBattery}%" : "100%");

            //CAMBIAR ICONO (LABEL22)
            BatteryChargeStatus chargeStatus = status.BatteryChargeStatus;
            PowerLineStatus powerLineStatus = status.PowerLineStatus;

            bool isCharging = chargeStatus.HasFlag(BatteryChargeStatus.Charging);
            bool isSaverOn = dosu.System.Power.BatteryStatus.IsBatterySaverOn();

            label22.Text = GetBatteryIcon(getBattery, isCharging, isSaverOn);
            /*await*/
            gws();
            gvs();

            if (globaldata.isImageLoaded)
            {
                BackColor = ColorTranslator.FromHtml(globaldata.wallpaperPredominantColorHex);
            }
        }
        async Task gws()
        {
            int wifiSignal = dosu.System.Network.WiFiStatus.GetWifiSignalStrengthAsync(Program.deneOSManifest).Result; // 0 - 100
            string wifiIcon;
            if (wifiSignal < 0)
                wifiIcon = ""; // no wifi
            else if (wifiSignal <= 25)
                wifiIcon = "";
            else if (wifiSignal <= 50)
                wifiIcon = "";
            else if (wifiSignal > 50)
                wifiIcon = "";

            else
                wifiIcon = "";

            // Mostrar en la UI
            label24.Text = wifiIcon;

        }
        void gvs()
        {
            int vol = dosu.Audio.VolumeManager.GetSystemVolume(); // 0 - 100
            string voli;
            if (vol == 0)
                voli = ""; // no volumen
            else if (vol > 0 && vol <= 33)
                voli = "";
            else if (vol > 33 && vol <= 66)
                voli = "";
            else if (vol > 66)
                voli = "";
            else
                voli = ""; // mute

            // Mostrar en la UI
            label23.Text = voli;
            ToolTip toolTip = new ToolTip();
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(label23, vol.ToString() + "%");
        }
        static string GetBatteryIcon(float percentage, bool charging, bool saverMode)
        {
            if (flagMgmt.MockBattery)
            {
                // Si se está simulando la batería, devolver un icono fijo
                return ""; // Icono de batería al 100% (simulado)
            }
            if (charging)
            {
                if (percentage >= 90) return "";
                if (percentage >= 80) return "";
                if (percentage >= 70) return "";
                if (percentage >= 60) return "";
                if (percentage >= 50) return "";
                if (percentage >= 40) return "";
                if (percentage >= 30) return "";
                if (percentage >= 20) return "";
                if (percentage >= 10) return "";
                if (percentage >= 5) return "";
                return ""; // batería crítica pero cargando
            }
            else if (saverMode)
            {
                if (percentage >= 90) return "";
                if (percentage >= 80) return "";
                if (percentage >= 70) return "";
                if (percentage >= 60) return "";
                if (percentage >= 50) return "";
                if (percentage >= 40) return "";
                if (percentage >= 30) return "";
                if (percentage >= 20) return "";
                if (percentage >= 10) return "";
                if (percentage >= 5) return "";
                return ""; // batería crítica pero ahorrando
            }
            else
            {
                if (percentage >= 90) return "";
                if (percentage >= 80) return "";
                if (percentage >= 70) return "";
                if (percentage >= 60) return "";
                if (percentage >= 50) return "";
                if (percentage >= 40) return "";
                if (percentage >= 30) return "";
                if (percentage >= 20) return "";
                if (percentage >= 10) return "";
                if (percentage >= 5) return "";
                return ""; // batería crítica
            }
        }

        
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            // ✅ Limpiar caché al cerrar
            dosu.UI.Scaling.ClearCache();
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);


        private void tbar_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true; // Evitar que se cierre el formulario
        }


        private void label23_Click(object sender, EventArgs e)
        {
            volSlider volSlider = new volSlider();
            var trigger = label23;
            var triggerScreenPos = trigger.PointToScreen(Point.Empty);

            // Centro horizontal del label
            int centerX = triggerScreenPos.X + trigger.Width / 2;

            // Tamaño del popup
            int popupWidth = volSlider.Width;
            int popupHeight = volSlider.Height;

            // Posición final del popup
            int popupX = centerX - (popupWidth / 2);
            int popupY = triggerScreenPos.Y - popupHeight - 10; // 10px encima

            volSlider.StartPosition = FormStartPosition.Manual;
            volSlider.Location = new Point(popupX, popupY);
            volSlider.Show();

        }
    }
}
