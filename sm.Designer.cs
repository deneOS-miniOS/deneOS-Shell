namespace deneOS
{
    partial class sm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BasePanel = new Panel();
            AppsFlowPnl = new FlowLayoutPanel();
            App0Pnl = new Panel();
            App0Category = new Label();
            App0Name = new Label();
            App0Icon = new PictureBox();
            App1Pnl = new Panel();
            App1Category = new Label();
            App1Name = new Label();
            App1Icon = new PictureBox();
            DockPnl = new Panel();
            dockRunBtn = new Button();
            this.dockrightR2Wbtn = new Button();
            dockResetBtn = new Button();
            dockShutdownBtn = new Button();
            DockLeftFlowPnl = new FlowLayoutPanel();
            App2Pnl = new Panel();
            App2Category = new Label();
            App2Name = new Label();
            App2Icon = new PictureBox();
            App3Pnl = new Panel();
            App3Category = new Label();
            App3Name = new Label();
            App3Icon = new PictureBox();
            App4Pnl = new Panel();
            App4Category = new Label();
            App4Name = new Label();
            App4Icon = new PictureBox();
            App5Pnl = new Panel();
            App5Category = new Label();
            App5Name = new Label();
            App5Icon = new PictureBox();
            App6Pnl = new Panel();
            App6Category = new Label();
            App6Name = new Label();
            App6Icon = new PictureBox();
            App7Pnl = new Panel();
            App7Category = new Label();
            App7Name = new Label();
            App7Icon = new PictureBox();
            BasePanel.SuspendLayout();
            AppsFlowPnl.SuspendLayout();
            App0Pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)App0Icon).BeginInit();
            App1Pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)App1Icon).BeginInit();
            DockPnl.SuspendLayout();
            DockLeftFlowPnl.SuspendLayout();
            App2Pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)App2Icon).BeginInit();
            App3Pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)App3Icon).BeginInit();
            App4Pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)App4Icon).BeginInit();
            App5Pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)App5Icon).BeginInit();
            App6Pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)App6Icon).BeginInit();
            App7Pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)App7Icon).BeginInit();
            SuspendLayout();
            // 
            // BasePanel
            // 
            BasePanel.Controls.Add(AppsFlowPnl);
            BasePanel.Controls.Add(DockPnl);
            BasePanel.Dock = DockStyle.Fill;
            BasePanel.Location = new Point(0, 0);
            BasePanel.Margin = new Padding(2);
            BasePanel.Name = "BasePanel";
            BasePanel.Size = new Size(378, 498);
            BasePanel.TabIndex = 2;
            // 
            // AppsFlowPnl
            // 
            AppsFlowPnl.BackColor = Color.Transparent;
            AppsFlowPnl.Controls.Add(App0Pnl);
            AppsFlowPnl.Controls.Add(App1Pnl);
            AppsFlowPnl.Controls.Add(App2Pnl);
            AppsFlowPnl.Controls.Add(App3Pnl);
            AppsFlowPnl.Controls.Add(App4Pnl);
            AppsFlowPnl.Controls.Add(App5Pnl);
            AppsFlowPnl.Controls.Add(App6Pnl);
            AppsFlowPnl.Controls.Add(App7Pnl);
            AppsFlowPnl.Dock = DockStyle.Fill;
            AppsFlowPnl.Location = new Point(0, 0);
            AppsFlowPnl.Margin = new Padding(2);
            AppsFlowPnl.Name = "AppsFlowPnl";
            AppsFlowPnl.Size = new Size(378, 452);
            AppsFlowPnl.TabIndex = 0;
            // 
            // App0Pnl
            // 
            App0Pnl.Controls.Add(App0Category);
            App0Pnl.Controls.Add(App0Name);
            App0Pnl.Controls.Add(App0Icon);
            App0Pnl.Dock = DockStyle.Top;
            App0Pnl.Location = new Point(2, 2);
            App0Pnl.Margin = new Padding(2);
            App0Pnl.Name = "App0Pnl";
            App0Pnl.Size = new Size(364, 52);
            App0Pnl.TabIndex = 5;
            App0Pnl.Click += panel4_Click;
            App0Pnl.Paint += panel4_Paint;
            // 
            // App0Category
            // 
            App0Category.Dock = DockStyle.Right;
            App0Category.Location = new Point(245, 0);
            App0Category.Margin = new Padding(2, 0, 2, 0);
            App0Category.Name = "App0Category";
            App0Category.Size = new Size(119, 52);
            App0Category.TabIndex = 2;
            App0Category.Text = "[0]";
            App0Category.TextAlign = ContentAlignment.MiddleRight;
            App0Category.Click += panel4_Click;
            // 
            // App0Name
            // 
            App0Name.Dock = DockStyle.Fill;
            App0Name.Font = new Font("Segoe UI", 16F);
            App0Name.Location = new Point(42, 0);
            App0Name.Margin = new Padding(2, 0, 2, 0);
            App0Name.Name = "App0Name";
            App0Name.Size = new Size(322, 52);
            App0Name.TabIndex = 1;
            App0Name.Text = "[0]";
            App0Name.TextAlign = ContentAlignment.MiddleLeft;
            App0Name.Click += panel4_Click;
            // 
            // App0Icon
            // 
            App0Icon.Dock = DockStyle.Left;
            App0Icon.Image = Properties.Resources.icons8_internet_100;
            App0Icon.Location = new Point(0, 0);
            App0Icon.Margin = new Padding(2);
            App0Icon.Name = "App0Icon";
            App0Icon.Size = new Size(42, 52);
            App0Icon.SizeMode = PictureBoxSizeMode.Zoom;
            App0Icon.TabIndex = 0;
            App0Icon.TabStop = false;
            App0Icon.Click += panel4_Click;
            // 
            // App1Pnl
            // 
            App1Pnl.Controls.Add(App1Category);
            App1Pnl.Controls.Add(App1Name);
            App1Pnl.Controls.Add(App1Icon);
            App1Pnl.Dock = DockStyle.Top;
            App1Pnl.Location = new Point(2, 58);
            App1Pnl.Margin = new Padding(2);
            App1Pnl.Name = "App1Pnl";
            App1Pnl.Size = new Size(364, 52);
            App1Pnl.TabIndex = 6;
            App1Pnl.Click += panel5_Click;
            // 
            // App1Category
            // 
            App1Category.Dock = DockStyle.Right;
            App1Category.Location = new Point(245, 0);
            App1Category.Margin = new Padding(2, 0, 2, 0);
            App1Category.Name = "App1Category";
            App1Category.Size = new Size(119, 52);
            App1Category.TabIndex = 2;
            App1Category.Text = "[1]";
            App1Category.TextAlign = ContentAlignment.MiddleRight;
            App1Category.Click += panel5_Click;
            // 
            // App1Name
            // 
            App1Name.Dock = DockStyle.Fill;
            App1Name.Font = new Font("Segoe UI", 16F);
            App1Name.Location = new Point(42, 0);
            App1Name.Margin = new Padding(2, 0, 2, 0);
            App1Name.Name = "App1Name";
            App1Name.Size = new Size(322, 52);
            App1Name.TabIndex = 1;
            App1Name.Text = "[1]";
            App1Name.TextAlign = ContentAlignment.MiddleLeft;
            App1Name.Click += panel5_Click;
            // 
            // App1Icon
            // 
            App1Icon.Dock = DockStyle.Left;
            App1Icon.Image = Properties.Resources.icons8_copybook_100;
            App1Icon.Location = new Point(0, 0);
            App1Icon.Margin = new Padding(2);
            App1Icon.Name = "App1Icon";
            App1Icon.Size = new Size(42, 52);
            App1Icon.SizeMode = PictureBoxSizeMode.Zoom;
            App1Icon.TabIndex = 0;
            App1Icon.TabStop = false;
            App1Icon.Click += panel5_Click;
            // 
            // DockPnl
            // 
            DockPnl.BackColor = Color.Transparent;
            DockPnl.Controls.Add(DockLeftFlowPnl);
            DockPnl.Controls.Add(this.dockrightR2Wbtn);
            DockPnl.Dock = DockStyle.Bottom;
            DockPnl.Location = new Point(0, 452);
            DockPnl.Margin = new Padding(2);
            DockPnl.Name = "DockPnl";
            DockPnl.Size = new Size(378, 46);
            DockPnl.TabIndex = 11;
            // 
            // dockRunBtn
            // 
            dockRunBtn.BackColor = Color.Transparent;
            dockRunBtn.BackgroundImage = Properties.Resources.icons8_run_command_100;
            dockRunBtn.BackgroundImageLayout = ImageLayout.Zoom;
            dockRunBtn.FlatStyle = FlatStyle.Popup;
            dockRunBtn.Location = new Point(94, 2);
            dockRunBtn.Margin = new Padding(2);
            dockRunBtn.Name = "dockRunBtn";
            dockRunBtn.Size = new Size(42, 38);
            dockRunBtn.TabIndex = 3;
            dockRunBtn.UseVisualStyleBackColor = false;
            dockRunBtn.Click += button1_Click;
            // 
            // dockrightR2Wbtn
            // 
            this.dockrightR2Wbtn.BackgroundImage = Properties.Resources.icons8_exit_100;
            this.dockrightR2Wbtn.BackgroundImageLayout = ImageLayout.Zoom;
            this.dockrightR2Wbtn.Dock = DockStyle.Right;
            this.dockrightR2Wbtn.FlatStyle = FlatStyle.Popup;
            this.dockrightR2Wbtn.Location = new Point(340, 0);
            this.dockrightR2Wbtn.Margin = new Padding(2);
            this.dockrightR2Wbtn.Name = "dockrightR2Wbtn";
            this.dockrightR2Wbtn.Size = new Size(38, 46);
            this.dockrightR2Wbtn.TabIndex = 2;
            this.dockrightR2Wbtn.UseVisualStyleBackColor = true;
            this.dockrightR2Wbtn.Click += this.button4_Click;
            // 
            // dockResetBtn
            // 
            dockResetBtn.BackColor = Color.Transparent;
            dockResetBtn.BackgroundImage = Properties.Resources.icons8_restart_100;
            dockResetBtn.BackgroundImageLayout = ImageLayout.Zoom;
            dockResetBtn.Dock = DockStyle.Left;
            dockResetBtn.FlatStyle = FlatStyle.Popup;
            dockResetBtn.Location = new Point(48, 2);
            dockResetBtn.Margin = new Padding(2);
            dockResetBtn.Name = "dockResetBtn";
            dockResetBtn.Size = new Size(42, 38);
            dockResetBtn.TabIndex = 1;
            dockResetBtn.UseVisualStyleBackColor = false;
            dockResetBtn.Click += button3_Click;
            // 
            // dockShutdownBtn
            // 
            dockShutdownBtn.BackColor = Color.Transparent;
            dockShutdownBtn.BackgroundImage = Properties.Resources.icons8_shutdown_100;
            dockShutdownBtn.BackgroundImageLayout = ImageLayout.Zoom;
            dockShutdownBtn.Dock = DockStyle.Left;
            dockShutdownBtn.FlatStyle = FlatStyle.Popup;
            dockShutdownBtn.Location = new Point(2, 2);
            dockShutdownBtn.Margin = new Padding(2);
            dockShutdownBtn.Name = "dockShutdownBtn";
            dockShutdownBtn.Size = new Size(42, 38);
            dockShutdownBtn.TabIndex = 0;
            dockShutdownBtn.UseVisualStyleBackColor = false;
            dockShutdownBtn.Click += button2_Click;
            // 
            // DockLeftFlowPnl
            // 
            DockLeftFlowPnl.Controls.Add(dockShutdownBtn);
            DockLeftFlowPnl.Controls.Add(dockResetBtn);
            DockLeftFlowPnl.Controls.Add(dockRunBtn);
            DockLeftFlowPnl.Dock = DockStyle.Left;
            DockLeftFlowPnl.Location = new Point(0, 0);
            DockLeftFlowPnl.Name = "DockLeftFlowPnl";
            DockLeftFlowPnl.Size = new Size(292, 46);
            DockLeftFlowPnl.TabIndex = 4;
            // 
            // App2Pnl
            // 
            App2Pnl.Controls.Add(App2Category);
            App2Pnl.Controls.Add(App2Name);
            App2Pnl.Controls.Add(App2Icon);
            App2Pnl.Dock = DockStyle.Top;
            App2Pnl.Location = new Point(2, 114);
            App2Pnl.Margin = new Padding(2);
            App2Pnl.Name = "App2Pnl";
            App2Pnl.Size = new Size(364, 52);
            App2Pnl.TabIndex = 7;
            // 
            // App2Category
            // 
            App2Category.Dock = DockStyle.Right;
            App2Category.Location = new Point(245, 0);
            App2Category.Margin = new Padding(2, 0, 2, 0);
            App2Category.Name = "App2Category";
            App2Category.Size = new Size(119, 52);
            App2Category.TabIndex = 2;
            App2Category.Text = "[2]";
            App2Category.TextAlign = ContentAlignment.MiddleRight;
            // 
            // App2Name
            // 
            App2Name.Dock = DockStyle.Fill;
            App2Name.Font = new Font("Segoe UI", 16F);
            App2Name.Location = new Point(42, 0);
            App2Name.Margin = new Padding(2, 0, 2, 0);
            App2Name.Name = "App2Name";
            App2Name.Size = new Size(322, 52);
            App2Name.TabIndex = 1;
            App2Name.Text = "[2]";
            App2Name.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // App2Icon
            // 
            App2Icon.Dock = DockStyle.Left;
            App2Icon.Image = Properties.Resources.icons8_copybook_100;
            App2Icon.Location = new Point(0, 0);
            App2Icon.Margin = new Padding(2);
            App2Icon.Name = "App2Icon";
            App2Icon.Size = new Size(42, 52);
            App2Icon.SizeMode = PictureBoxSizeMode.Zoom;
            App2Icon.TabIndex = 0;
            App2Icon.TabStop = false;
            // 
            // App3Pnl
            // 
            App3Pnl.Controls.Add(App3Category);
            App3Pnl.Controls.Add(App3Name);
            App3Pnl.Controls.Add(App3Icon);
            App3Pnl.Dock = DockStyle.Top;
            App3Pnl.Location = new Point(2, 170);
            App3Pnl.Margin = new Padding(2);
            App3Pnl.Name = "App3Pnl";
            App3Pnl.Size = new Size(364, 52);
            App3Pnl.TabIndex = 8;
            // 
            // App3Category
            // 
            App3Category.Dock = DockStyle.Right;
            App3Category.Location = new Point(245, 0);
            App3Category.Margin = new Padding(2, 0, 2, 0);
            App3Category.Name = "App3Category";
            App3Category.Size = new Size(119, 52);
            App3Category.TabIndex = 2;
            App3Category.Text = "[3]";
            App3Category.TextAlign = ContentAlignment.MiddleRight;
            // 
            // App3Name
            // 
            App3Name.Dock = DockStyle.Fill;
            App3Name.Font = new Font("Segoe UI", 16F);
            App3Name.Location = new Point(42, 0);
            App3Name.Margin = new Padding(2, 0, 2, 0);
            App3Name.Name = "App3Name";
            App3Name.Size = new Size(322, 52);
            App3Name.TabIndex = 1;
            App3Name.Text = "[3]";
            App3Name.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // App3Icon
            // 
            App3Icon.Dock = DockStyle.Left;
            App3Icon.Image = Properties.Resources.icons8_copybook_100;
            App3Icon.Location = new Point(0, 0);
            App3Icon.Margin = new Padding(2);
            App3Icon.Name = "App3Icon";
            App3Icon.Size = new Size(42, 52);
            App3Icon.SizeMode = PictureBoxSizeMode.Zoom;
            App3Icon.TabIndex = 0;
            App3Icon.TabStop = false;
            // 
            // App4Pnl
            // 
            App4Pnl.Controls.Add(App4Category);
            App4Pnl.Controls.Add(App4Name);
            App4Pnl.Controls.Add(App4Icon);
            App4Pnl.Dock = DockStyle.Top;
            App4Pnl.Location = new Point(2, 226);
            App4Pnl.Margin = new Padding(2);
            App4Pnl.Name = "App4Pnl";
            App4Pnl.Size = new Size(364, 52);
            App4Pnl.TabIndex = 9;
            // 
            // App4Category
            // 
            App4Category.Dock = DockStyle.Right;
            App4Category.Location = new Point(245, 0);
            App4Category.Margin = new Padding(2, 0, 2, 0);
            App4Category.Name = "App4Category";
            App4Category.Size = new Size(119, 52);
            App4Category.TabIndex = 2;
            App4Category.Text = "[4]";
            App4Category.TextAlign = ContentAlignment.MiddleRight;
            // 
            // App4Name
            // 
            App4Name.Dock = DockStyle.Fill;
            App4Name.Font = new Font("Segoe UI", 16F);
            App4Name.Location = new Point(42, 0);
            App4Name.Margin = new Padding(2, 0, 2, 0);
            App4Name.Name = "App4Name";
            App4Name.Size = new Size(322, 52);
            App4Name.TabIndex = 1;
            App4Name.Text = "[4]";
            App4Name.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // App4Icon
            // 
            App4Icon.Dock = DockStyle.Left;
            App4Icon.Image = Properties.Resources.icons8_copybook_100;
            App4Icon.Location = new Point(0, 0);
            App4Icon.Margin = new Padding(2);
            App4Icon.Name = "App4Icon";
            App4Icon.Size = new Size(42, 52);
            App4Icon.SizeMode = PictureBoxSizeMode.Zoom;
            App4Icon.TabIndex = 0;
            App4Icon.TabStop = false;
            // 
            // App5Pnl
            // 
            App5Pnl.Controls.Add(App5Category);
            App5Pnl.Controls.Add(App5Name);
            App5Pnl.Controls.Add(App5Icon);
            App5Pnl.Dock = DockStyle.Top;
            App5Pnl.Location = new Point(2, 282);
            App5Pnl.Margin = new Padding(2);
            App5Pnl.Name = "App5Pnl";
            App5Pnl.Size = new Size(364, 52);
            App5Pnl.TabIndex = 10;
            // 
            // App5Category
            // 
            App5Category.Dock = DockStyle.Right;
            App5Category.Location = new Point(245, 0);
            App5Category.Margin = new Padding(2, 0, 2, 0);
            App5Category.Name = "App5Category";
            App5Category.Size = new Size(119, 52);
            App5Category.TabIndex = 2;
            App5Category.Text = "[5]";
            App5Category.TextAlign = ContentAlignment.MiddleRight;
            // 
            // App5Name
            // 
            App5Name.Dock = DockStyle.Fill;
            App5Name.Font = new Font("Segoe UI", 16F);
            App5Name.Location = new Point(42, 0);
            App5Name.Margin = new Padding(2, 0, 2, 0);
            App5Name.Name = "App5Name";
            App5Name.Size = new Size(322, 52);
            App5Name.TabIndex = 1;
            App5Name.Text = "[5]";
            App5Name.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // App5Icon
            // 
            App5Icon.Dock = DockStyle.Left;
            App5Icon.Image = Properties.Resources.icons8_copybook_100;
            App5Icon.Location = new Point(0, 0);
            App5Icon.Margin = new Padding(2);
            App5Icon.Name = "App5Icon";
            App5Icon.Size = new Size(42, 52);
            App5Icon.SizeMode = PictureBoxSizeMode.Zoom;
            App5Icon.TabIndex = 0;
            App5Icon.TabStop = false;
            // 
            // App6Pnl
            // 
            App6Pnl.Controls.Add(App6Category);
            App6Pnl.Controls.Add(App6Name);
            App6Pnl.Controls.Add(App6Icon);
            App6Pnl.Dock = DockStyle.Top;
            App6Pnl.Location = new Point(2, 338);
            App6Pnl.Margin = new Padding(2);
            App6Pnl.Name = "App6Pnl";
            App6Pnl.Size = new Size(364, 52);
            App6Pnl.TabIndex = 11;
            // 
            // App6Category
            // 
            App6Category.Dock = DockStyle.Right;
            App6Category.Location = new Point(245, 0);
            App6Category.Margin = new Padding(2, 0, 2, 0);
            App6Category.Name = "App6Category";
            App6Category.Size = new Size(119, 52);
            App6Category.TabIndex = 2;
            App6Category.Text = "[6]";
            App6Category.TextAlign = ContentAlignment.MiddleRight;
            // 
            // App6Name
            // 
            App6Name.Dock = DockStyle.Fill;
            App6Name.Font = new Font("Segoe UI", 16F);
            App6Name.Location = new Point(42, 0);
            App6Name.Margin = new Padding(2, 0, 2, 0);
            App6Name.Name = "App6Name";
            App6Name.Size = new Size(322, 52);
            App6Name.TabIndex = 1;
            App6Name.Text = "[6]";
            App6Name.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // App6Icon
            // 
            App6Icon.Dock = DockStyle.Left;
            App6Icon.Image = Properties.Resources.icons8_copybook_100;
            App6Icon.Location = new Point(0, 0);
            App6Icon.Margin = new Padding(2);
            App6Icon.Name = "App6Icon";
            App6Icon.Size = new Size(42, 52);
            App6Icon.SizeMode = PictureBoxSizeMode.Zoom;
            App6Icon.TabIndex = 0;
            App6Icon.TabStop = false;
            // 
            // App7Pnl
            // 
            App7Pnl.Controls.Add(App7Category);
            App7Pnl.Controls.Add(App7Name);
            App7Pnl.Controls.Add(App7Icon);
            App7Pnl.Dock = DockStyle.Top;
            App7Pnl.Location = new Point(2, 394);
            App7Pnl.Margin = new Padding(2);
            App7Pnl.Name = "App7Pnl";
            App7Pnl.Size = new Size(364, 52);
            App7Pnl.TabIndex = 12;
            // 
            // App7Category
            // 
            App7Category.Dock = DockStyle.Right;
            App7Category.Location = new Point(245, 0);
            App7Category.Margin = new Padding(2, 0, 2, 0);
            App7Category.Name = "App7Category";
            App7Category.Size = new Size(119, 52);
            App7Category.TabIndex = 2;
            App7Category.Text = "[7]";
            App7Category.TextAlign = ContentAlignment.MiddleRight;
            // 
            // App7Name
            // 
            App7Name.Dock = DockStyle.Fill;
            App7Name.Font = new Font("Segoe UI", 16F);
            App7Name.Location = new Point(42, 0);
            App7Name.Margin = new Padding(2, 0, 2, 0);
            App7Name.Name = "App7Name";
            App7Name.Size = new Size(322, 52);
            App7Name.TabIndex = 1;
            App7Name.Text = "[7]";
            App7Name.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // App7Icon
            // 
            App7Icon.Dock = DockStyle.Left;
            App7Icon.Image = Properties.Resources.icons8_copybook_100;
            App7Icon.Location = new Point(0, 0);
            App7Icon.Margin = new Padding(2);
            App7Icon.Name = "App7Icon";
            App7Icon.Size = new Size(42, 52);
            App7Icon.SizeMode = PictureBoxSizeMode.Zoom;
            App7Icon.TabIndex = 0;
            App7Icon.TabStop = false;
            // 
            // sm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.ControlText;
            ClientSize = new Size(378, 498);
            Controls.Add(BasePanel);
            Font = new Font("Segoe UI Variable Display", 12F);
            ForeColor = SystemColors.Control;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "sm";
            Opacity = 0.75D;
            StartPosition = FormStartPosition.Manual;
            Text = "sm";
            Deactivate += sm_Deactivate;
            Load += sm_Load;
            BasePanel.ResumeLayout(false);
            AppsFlowPnl.ResumeLayout(false);
            App0Pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)App0Icon).EndInit();
            App1Pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)App1Icon).EndInit();
            DockPnl.ResumeLayout(false);
            DockLeftFlowPnl.ResumeLayout(false);
            App2Pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)App2Icon).EndInit();
            App3Pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)App3Icon).EndInit();
            App4Pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)App4Icon).EndInit();
            App5Pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)App5Icon).EndInit();
            App6Pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)App6Icon).EndInit();
            App7Pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)App7Icon).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BasePanel;
        private System.Windows.Forms.FlowLayoutPanel AppsFlowPnl;
        private System.Windows.Forms.Panel App0Pnl;
        private System.Windows.Forms.Label App0Category;
        private System.Windows.Forms.Label App0Name;
        private System.Windows.Forms.PictureBox App0Icon;
        private System.Windows.Forms.Panel App1Pnl;
        private System.Windows.Forms.Label App1Category;
        private System.Windows.Forms.Label App1Name;
        private System.Windows.Forms.PictureBox App1Icon;
        private System.Windows.Forms.Label dnu;
        private System.Windows.Forms.PictureBox dnupdPic;
        private System.Windows.Forms.Label ie;
        private System.Windows.Forms.PictureBox ie11minPic;
        private System.Windows.Forms.Label cio;
        private System.Windows.Forms.PictureBox calendarPic;
        private System.Windows.Forms.Label term;
        private System.Windows.Forms.PictureBox termPic;
        private System.Windows.Forms.Panel DockPnl;
        private System.Windows.Forms.Button dockrightR2Wbtn;
        private System.Windows.Forms.Button dockResetBtn;
        private System.Windows.Forms.Button dockShutdownBtn;
        private Button dockRunBtn;
        private FlowLayoutPanel DockLeftFlowPnl;
        private Panel App2Pnl;
        private Label App2Category;
        private Label App2Name;
        private PictureBox App2Icon;
        private Panel App3Pnl;
        private Label App3Category;
        private Label App3Name;
        private PictureBox App3Icon;
        private Panel App4Pnl;
        private Label App4Category;
        private Label App4Name;
        private PictureBox App4Icon;
        private Panel App5Pnl;
        private Label App5Category;
        private Label App5Name;
        private PictureBox App5Icon;
        private Panel App6Pnl;
        private Label App6Category;
        private Label App6Name;
        private PictureBox App6Icon;
        private Panel App7Pnl;
        private Label App7Category;
        private Label App7Name;
        private PictureBox App7Icon;
    }
}