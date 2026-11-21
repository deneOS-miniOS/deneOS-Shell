namespace deneOS
{
    partial class BottomBar
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
            button1 = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackgroundImage = Properties.Resources.deneOS_Logo;
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.Dock = DockStyle.Fill;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(249, 3);
            button1.Name = "button1";
            button1.Size = new Size(240, 58);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(button1, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(739, 64);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // BottomBar
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.ControlText;
            ClientSize = new Size(739, 64);
            Controls.Add(tableLayoutPanel1);
            ForeColor = SystemColors.Control;
            FormBorderStyle = FormBorderStyle.None;
            Name = "BottomBar";
            StartPosition = FormStartPosition.Manual;
            Text = "BottomBar";
            Load += BottomBar_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private TableLayoutPanel tableLayoutPanel1;
    }
}