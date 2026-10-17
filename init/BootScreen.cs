using System;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace deneOS.init
{
    /// <summary>
    /// Única pantalla de arranque de deneOS.
    /// El diseño se adapta a la orientación mediante el TableLayoutPanel del Designer.
    /// </summary>
    public partial class BootScreen : BootScreenBase
    {
        protected override Label SpinnerLabel => label1;
        protected override Timer TransitionTimer => timer1;

        public BootScreen()
        {
            InitializeComponent();
            InitializeBootFlow();
        }

        private void BootScreen_Load(object sender, EventArgs e) => RunBootChecks();

        private void timer1_Tick(object sender, EventArgs e) => OnTransitionTimerTick(sender, e);
    }
}
