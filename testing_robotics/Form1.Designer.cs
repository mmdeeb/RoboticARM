namespace RoboticARM
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            timer1 = new System.Windows.Forms.Timer(components);
            labelX = new Label();
            labelY = new Label();
            pictureBox2 = new PictureBox();
            pictureBox5 = new PictureBox();
            labelTheta1 = new Label();
            labelTheta2 = new Label();
            button1 = new Button();
            error = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1;
            timer1.Tick += timer1_Tick;
            // 
            // labelX
            // 
            labelX.AutoSize = true;
            labelX.BackColor = Color.FromArgb(189, 215, 238);
            labelX.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelX.Location = new Point(97, 103);
            labelX.Name = "labelX";
            labelX.Size = new Size(15, 17);
            labelX.TabIndex = 4;
            labelX.Text = "0";
            // 
            // labelY
            // 
            labelY.AutoSize = true;
            labelY.BackColor = Color.FromArgb(189, 215, 238);
            labelY.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelY.Location = new Point(97, 165);
            labelY.Name = "labelY";
            labelY.Size = new Size(15, 17);
            labelY.TabIndex = 6;
            labelY.Text = "0";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(24, 71);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(150, 150);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(24, 253);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(150, 150);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 10;
            pictureBox5.TabStop = false;
            // 
            // labelTheta1
            // 
            labelTheta1.AutoSize = true;
            labelTheta1.BackColor = Color.FromArgb(197, 224, 180);
            labelTheta1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelTheta1.Location = new Point(97, 282);
            labelTheta1.Name = "labelTheta1";
            labelTheta1.Size = new Size(15, 17);
            labelTheta1.TabIndex = 11;
            labelTheta1.Text = "0";
            // 
            // labelTheta2
            // 
            labelTheta2.AutoSize = true;
            labelTheta2.BackColor = Color.FromArgb(197, 224, 180);
            labelTheta2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelTheta2.Location = new Point(96, 352);
            labelTheta2.Name = "labelTheta2";
            labelTheta2.Size = new Size(15, 17);
            labelTheta2.TabIndex = 12;
            labelTheta2.Text = "0";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(189, 215, 238);
            button1.Cursor = Cursors.Hand;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(44, 441);
            button1.Name = "button1";
            button1.Size = new Size(102, 45);
            button1.TabIndex = 13;
            button1.Text = "send";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // error
            // 
            error.AutoSize = true;
            error.ForeColor = Color.Red;
            error.Location = new Point(24, 418);
            error.Name = "error";
            error.Size = new Size(0, 15);
            error.TabIndex = 14;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Location = new Point(2, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1106, 621);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.MouseClick += pictureBox1_MouseClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1109, 623);
            Controls.Add(error);
            Controls.Add(button1);
            Controls.Add(labelTheta2);
            Controls.Add(labelTheta1);
            Controls.Add(labelY);
            Controls.Add(labelX);
            Controls.Add(pictureBox5);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RoboticARM";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private Label labelX;
        private Label labelY;
        private PictureBox pictureBox2;
        private PictureBox pictureBox5;
        private Label labelTheta1;
        private Label labelTheta2;
        private Button button1;
        private Label error;
        private PictureBox pictureBox1;
    }
}