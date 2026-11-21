namespace deneOS
{
    partial class Run
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
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            pictureBox2 = new PictureBox();
            panel1 = new Panel();
            panel2 = new Panel();
            button1 = new Button();
            label3 = new Label();
            textBox1 = new TextBox();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = Properties.Resources.icons8_run_command_100;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(39, 29);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Left;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(289, 29);
            label1.TabIndex = 1;
            label1.Text = "Run";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(92, 47);
            label2.Name = "label2";
            label2.Size = new Size(289, 30);
            label2.TabIndex = 3;
            label2.Text = "Type the program name, folder, document or website\r\nyou want to open on deneOS.";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.icons8_run_command_100;
            pictureBox2.Location = new Point(0, 40);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(86, 42);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(415, 29);
            panel1.TabIndex = 4;
            panel1.MouseDown += panel1_MouseDown;
            // 
            // panel2
            // 
            panel2.Controls.Add(button1);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(39, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(376, 29);
            panel2.TabIndex = 2;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Right;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe Fluent Icons", 9F);
            button1.Location = new Point(350, 0);
            button1.Name = "button1";
            button1.Size = new Size(26, 29);
            button1.TabIndex = 2;
            button1.Text = "";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 91);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 5;
            label3.Text = "&Open:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(57, 88);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(265, 23);
            textBox1.TabIndex = 6;
            // 
            // button2
            // 
            button2.Location = new Point(328, 87);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 7;
            button2.Text = "&OK";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Run
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(415, 123);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(pictureBox2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Run";
            Text = "Run";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox2;
        private Panel panel1;
        private Panel panel2;
        private Button button1;
        private Label label3;
        private TextBox textBox1;
        private Button button2;
    }
}