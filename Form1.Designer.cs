namespace Bloxshade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1 = new PictureBox();
            userControl11 = new UserControl1();
            userControl21 = new UserControl2();
            userControl31 = new UserControl3();
            userControl41 = new UserControl4();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.extravi_reshade;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(-2, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(177, 370);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // userControl11
            // 
            userControl11.BackColor = Color.FromArgb(17, 17, 17);
            userControl11.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            userControl11.Location = new Point(171, -1);
            userControl11.Name = "userControl11";
            userControl11.Size = new Size(330, 370);
            userControl11.TabIndex = 1;
            userControl11.Load += userControl11_Load;
            // 
            // userControl21
            // 
            userControl21.BackColor = Color.FromArgb(17, 17, 17);
            userControl21.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            userControl21.Location = new Point(171, -1);
            userControl21.Name = "userControl21";
            userControl21.Size = new Size(330, 370);
            userControl21.TabIndex = 2;
            userControl21.Load += userControl21_Load;
            // 
            // userControl31
            // 
            userControl31.BackColor = Color.FromArgb(17, 17, 17);
            userControl31.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            userControl31.Location = new Point(171, -1);
            userControl31.Name = "userControl31";
            userControl31.Size = new Size(330, 370);
            userControl31.TabIndex = 3;
            userControl31.Load += userControl31_Load;
            // 
            // userControl41
            // 
            userControl41.BackColor = Color.FromArgb(17, 17, 17);
            userControl41.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            userControl41.Location = new Point(171, -1);
            userControl41.Name = "userControl41";
            userControl41.Size = new Size(330, 370);
            userControl41.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(17, 17, 17);
            ClientSize = new Size(504, 361);
            Controls.Add(userControl41);
            Controls.Add(userControl31);
            Controls.Add(userControl21);
            Controls.Add(userControl11);
            Controls.Add(pictureBox1);
            Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Setup - Bloxshade";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        public UserControl3 userControl31;
        public UserControl1 userControl11;
        public UserControl2 userControl21;
        public UserControl4 userControl41;
    }
}
