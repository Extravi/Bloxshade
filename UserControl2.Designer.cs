namespace Bloxshade
{
    partial class UserControl2
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label2 = new Label();
            button1 = new Button();
            label1 = new Label();
            richTextBox1 = new RichTextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(218, 229, 236);
            label2.Location = new Point(8, 87);
            label2.MinimumSize = new Size(296, 48);
            label2.Name = "label2";
            label2.Size = new Size(296, 48);
            label2.TabIndex = 5;
            label2.Text = "Please wait while Bloxshade is being installed.";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(31, 31, 31);
            button1.FlatAppearance.BorderColor = Color.FromArgb(54, 58, 60);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(156, 163, 175);
            button1.Location = new Point(227, 330);
            button1.Name = "button1";
            button1.Size = new Size(100, 27);
            button1.TabIndex = 4;
            button1.Text = "Next";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(218, 229, 236);
            label1.Location = new Point(8, 10);
            label1.MinimumSize = new Size(296, 48);
            label1.Name = "label1";
            label1.Size = new Size(296, 48);
            label1.TabIndex = 3;
            label1.Text = "Bloxshade - Improve Roblox\r\nwith shaders.";
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.FromArgb(31, 31, 31);
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Font = new Font("Cascadia Code", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox1.ForeColor = Color.FromArgb(218, 229, 236);
            richTextBox1.Location = new Point(8, 111);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.None;
            richTextBox1.Size = new Size(296, 213);
            richTextBox1.TabIndex = 6;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(218, 229, 236);
            label3.Location = new Point(8, 58);
            label3.MinimumSize = new Size(296, 22);
            label3.Name = "label3";
            label3.Size = new Size(296, 22);
            label3.TabIndex = 7;
            label3.Text = "Installing...";
            // 
            // UserControl2
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            BackColor = Color.FromArgb(17, 17, 17);
            Controls.Add(label3);
            Controls.Add(richTextBox1);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label1);
            Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "UserControl2";
            Size = new Size(330, 360);
            Load += UserControl2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Button button1;
        private Label label1;
        private Label label3;
        private RichTextBox richTextBox1;
    }
}
