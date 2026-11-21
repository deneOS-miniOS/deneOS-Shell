namespace deneOS
{
    partial class TopBar
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
            label19 = new Label();
            flowLayoutPanel3 = new FlowLayoutPanel();
            label22 = new Label();
            label23 = new Label();
            label24 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 30F);
            label19.Location = new Point(3, 0);
            label19.Name = "label19";
            label19.Size = new Size(120, 54);
            label19.TabIndex = 0;
            label19.Text = "00:00";
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.BackColor = Color.Transparent;
            flowLayoutPanel3.Controls.Add(label22);
            flowLayoutPanel3.Controls.Add(label23);
            flowLayoutPanel3.Controls.Add(label24);
            flowLayoutPanel3.Dock = DockStyle.Fill;
            flowLayoutPanel3.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel3.Location = new Point(145, 3);
            flowLayoutPanel3.Margin = new Padding(3, 3, 0, 3);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(568, 54);
            flowLayoutPanel3.TabIndex = 0;
            // 
            // label22
            // 
            label22.Font = new Font("Segoe Fluent Icons", 16F);
            label22.Location = new Point(530, 0);
            label22.Name = "label22";
            label22.Size = new Size(35, 54);
            label22.TabIndex = 4;
            label22.Text = "";
            label22.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            label23.Font = new Font("Segoe Fluent Icons", 16F);
            label23.Location = new Point(489, 0);
            label23.Name = "label23";
            label23.Size = new Size(35, 54);
            label23.TabIndex = 5;
            label23.Text = "";
            label23.TextAlign = ContentAlignment.MiddleRight;
            label23.Click += label23_Click;
            // 
            // label24
            // 
            label24.Font = new Font("Segoe Fluent Icons", 16F);
            label24.Location = new Point(448, 0);
            label24.Name = "label24";
            label24.Size = new Size(35, 54);
            label24.TabIndex = 6;
            label24.Text = "";
            label24.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.Controls.Add(label19, 0, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel3, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(713, 60);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // TopBar
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.ControlText;
            ClientSize = new Size(713, 60);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI Variable Display", 12F);
            ForeColor = SystemColors.Control;
            FormBorderStyle = FormBorderStyle.None;
            Name = "TopBar";
            StartPosition = FormStartPosition.Manual;
            Text = "tbar";
            FormClosing += tbar_FormClosing;
            Load += tbar_Load;
            flowLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private TableLayoutPanel tableLayoutPanel1;
    }
}