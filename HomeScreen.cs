using System;
using System.Diagnostics;
using Color = System.Drawing.Color;


namespace deneOS
{
    public partial class HomeScreen : DesktopBase
    {
        private BuildWatermark marcaDeAgua;
        protected override FlowLayoutPanel IconsPanel => flowLayoutPanel2;

        protected override void SetTransparentPanels()
        {
            //flowLayoutPanel2.BackColor = Color.Transparent;
        }

        public HomeScreen()
        {
            InitializeComponent();

            marcaDeAgua = new BuildWatermark();

            // 3. (Opcional) Personaliza los textos si lo deseas
            marcaDeAgua.TitleText = "deneOS v0.5b";
            marcaDeAgua.BuildText = "Test Mode";

            // 4. Lo añadimos a los controles del Formulario
            this.Controls.Add(marcaDeAgua);

            // 5. Nos aseguramos de que se dibuje por ENCIMA de otros fondos
            marcaDeAgua.BringToFront();
        }

        private void desktop_Load(object sender, EventArgs e)
{
    ConfigureDesktopBounds();
    LoadDesktop();

            Console.WriteLine(
    $"[{GetType().Name}] " +
    $"Location={Location}, " +
    $"Size={Size}, " +
    $"Bounds={Bounds}, " +
    $"Visible={Visible}, " +
    $"TopMost={TopMost}"
);
        }


        int GetTopBarHeight()
        {
            var topBar = Application.OpenForms.OfType<TopBar>().FirstOrDefault();
            return topBar?.Height ?? 48; // Valor por defecto si no se encuentra TopBar
        }
        int GetBottomBarHeight()
        {
            var bottomBar = Application.OpenForms.OfType<BottomBar>().FirstOrDefault();
            return bottomBar?.Height ?? 64; // Valor por defecto si no se encuentra BottomBar
        }
        private void ConfigureDesktopBounds()
        {
            var primaryScreen = Screen.PrimaryScreen
                ?? Screen.AllScreens.FirstOrDefault();

            int screenWidth = primaryScreen?.Bounds.Width ?? 1920;
            int screenHeight = primaryScreen?.Bounds.Height ?? 1080;

            float dpiScale = tbar.GetDpiScale();

            int scaledTopBarHeight = (int)(48 * dpiScale + 0.5f);
            int topBarHeight = scaledTopBarHeight < 48 ? 48 : scaledTopBarHeight;

            int scaledBottomBarHeight = (int)(64 * dpiScale + 0.5f);
            int bottomBarHeight = scaledBottomBarHeight < 64 ? 64 : scaledBottomBarHeight;
            this.SuspendLayout();

            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;

            this.Location = new Point(0, topBarHeight);
            this.Size = new Size(
                screenWidth,
                screenHeight - topBarHeight - bottomBarHeight
            );

            this.ResumeLayout();

            Console.WriteLine(
                $"[INFO] HomeScreen bounds: {this.Bounds}"
            );
        }
        private void panel12_Click(object sender, EventArgs e) => Process.Start(@"C:\DENEOS\core\deneStore.exe");
        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e) { }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
    public class BuildWatermark : Label
    {
        // Tamaños base originales en puntos (pt) a 96 DPI
        private const float TitleFontSizePt = 9.75f;
        private const float BuildFontSizePt = 9.0f;
        private const int BasePaddingPx = 16; // Margen de 16px a 100% de escala

        private Font titleFont;
        private Font buildFont;

        [System.ComponentModel.DesignerSerializationVisibility(
            System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public string TitleText { get; set; } = "deneOS v0.5b";

        [System.ComponentModel.DesignerSerializationVisibility(
            System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public string BuildText { get; set; } = "Test Mode";


        public BuildWatermark()
        {
            // Configuraciones iniciales del Label
            this.AutoSize = false;
            this.BackColor = Color.Transparent;
            this.ForeColor = Color.White;

            // Activamos DoubleBuffered para evitar parpadeos al redimensionar
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);

            ActualizarFuentesYDimensiones();
        }

        // Este método recalcula las fuentes y márgenes basándose en el DPI actual del dispositivo
        private void ActualizarFuentesYDimensiones()
        {
            // En .NET 10, obtenemos el DPI actual del control de forma nativa
            int currentDpi = this.DeviceDpi;
            float escalaFactor = currentDpi / 96f;

            // Liberar fuentes anteriores si existen
            titleFont?.Dispose();
            buildFont?.Dispose();

            // En WinForms, cuando AutoScaleMode = Dpi, es más seguro definir el tamaño de la fuente 
            // explícitamente en GraphicsUnit.Point para que el sistema operativo la escale de manera fluida.
            titleFont = new Font("Segoe UI", TitleFontSizePt, FontStyle.Regular, GraphicsUnit.Point);
            buildFont = new Font("Segoe UI", BuildFontSizePt, FontStyle.Regular, GraphicsUnit.Point);

            // Escalamos el padding/margen de la esquina inferior derecha
            int margenEscalado = (int)global::System.MathF.Round(BasePaddingPx * escalaFactor);

            // Ajustar el tamaño del Label para albergar el texto cómodamente sin recortarse
            this.Width = (int)(350 * escalaFactor);
            this.Height = (int)(50 * escalaFactor);

            if (this.Parent != null)
            {
                // Posicionar exactamente abajo a la derecha de su contenedor/formulario
                this.Left = this.Parent.ClientSize.Width - this.Width - margenEscalado;
                this.Top = this.Parent.ClientSize.Height - this.Height - margenEscalado;
            }
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            if (this.Parent != null)
            {
                // Nos aseguramos de reubicarnos si el formulario padre cambia de tamaño
                this.Parent.Resize += (s, ev) => ActualizarFuentesYDimensiones();
            }
            ActualizarFuentesYDimensiones();
        }

        // Evento nativo de .NET que se dispara cuando el formulario se mueve a un monitor con diferente DPI
        protected override void OnDpiChangedAfterParent(EventArgs e)
        {
            base.OnDpiChangedAfterParent(e);
            ActualizarFuentesYDimensiones();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Habilitar renderizado de texto de alta calidad (Anti-alias)
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // Configurar la alineación del texto a la derecha
            StringFormat format = new StringFormat
            {
                Alignment = StringAlignment.Far, // Alineado a la derecha
                LineAlignment = StringAlignment.Near
            };

            // Medidas para posicionar la segunda línea debajo de la primera
            Size titleSize = TextRenderer.MeasureText(TitleText, titleFont);

            // Dibujar sombreado sutil (Drop Shadow) para emular el comportamiento de Windows
            // Desplazamos 1 píxel abajo y a la derecha en color negro translúcido
            using (Brush shadowBrush = new SolidBrush(Color.FromArgb(150, 0, 0, 0)))
            {
                g.DrawString(TitleText, titleFont, shadowBrush, new RectangleF(1, 1, this.Width, this.Height), format);
                g.DrawString(BuildText, buildFont, shadowBrush, new RectangleF(1, titleSize.Height + 1, this.Width, this.Height), format);
            }

            // Dibujar el texto principal en blanco puro
            using (Brush textBrush = new SolidBrush(Color.White))
            {
                g.DrawString(TitleText, titleFont, textBrush, new RectangleF(0, 0, this.Width, this.Height), format);
                g.DrawString(BuildText, buildFont, textBrush, new RectangleF(0, titleSize.Height, this.Width, this.Height), format);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                titleFont?.Dispose();
                buildFont?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
