namespace deneOS.init
{
    partial class BootScreen
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
            components = new System.ComponentModel.Container();
            timer1 = new System.Windows.Forms.Timer(components);
            tableLayoutPanelBoot = new TableLayoutPanel();
            logo = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            tableLayoutPanelBoot.SuspendLayout();
            SuspendLayout();
            // 
            // timer1
            // 
            // Start it from InitializeBootFlow only after the normal boot screen is shown.
            timer1.Interval = 6000;
            timer1.Tick += timer1_Tick;
            // 
            // tableLayoutPanelBoot
            // 
            tableLayoutPanelBoot.ColumnCount = 1;
            tableLayoutPanelBoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelBoot.Dock = DockStyle.Fill;
            tableLayoutPanelBoot.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanelBoot.Location = new Point(0, 0);
            tableLayoutPanelBoot.Margin = Padding.Empty;
            tableLayoutPanelBoot.Name = "tableLayoutPanelBoot";
            tableLayoutPanelBoot.Padding = Padding.Empty;
            tableLayoutPanelBoot.RowCount = 3;
            tableLayoutPanelBoot.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanelBoot.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanelBoot.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanelBoot.Size = new Size(960, 540);
            tableLayoutPanelBoot.TabIndex = 0;
            tableLayoutPanelBoot.Controls.Add(logo, 0, 0);
            tableLayoutPanelBoot.Controls.Add(label1, 0, 2);
            // 
            // logo
            // 
            logo.Dock = DockStyle.Fill;
            logo.Image = Properties.Resources.denelogo;
            logo.Location = new Point(3, 3);
            logo.Margin = new Padding(0);
            logo.Name = "logo";
            logo.Size = new Size(954, 210);
            logo.SizeMode = PictureBoxSizeMode.Zoom;
            logo.TabIndex = 0;
            logo.TabStop = false;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe Boot Semilight", 52F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 324);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(954, 213);
            label1.TabIndex = 2;
            label1.Text = "";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BootScreen
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.Black;
            ClientSize = new Size(960, 540);
            ControlBox = false;
            Controls.Add(tableLayoutPanelBoot);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = SystemColors.Control;
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BootScreen";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "deninit";
            WindowState = FormWindowState.Maximized;
            Load += BootScreen_Load;
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            tableLayoutPanelBoot.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBoot;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Label label1;
    }
}
