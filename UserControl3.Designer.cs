namespace Bloxshade
{
    partial class UserControl3
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
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(218, 229, 236);
            label2.Location = new Point(8, 67);
            label2.MinimumSize = new Size(296, 48);
            label2.Name = "label2";
            label2.Size = new Size(296, 80);
            label2.TabIndex = 5;
            label2.Text = "Setup has finished installing Bloxshade on your\r\ncomputer. The effects will be applied the next\r\ntime you launch Roblox.\r\n\r\nClick Finish to exit Setup.";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(31, 31, 31);
            button1.FlatAppearance.BorderColor = Color.FromArgb(54, 58, 60);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(218, 229, 236);
            button1.Location = new Point(227, 330);
            button1.Name = "button1";
            button1.Size = new Size(100, 27);
            button1.TabIndex = 4;
            button1.Text = "Finish";
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
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Font = new Font("Arial", 9.75F);
            checkBox1.ForeColor = Color.FromArgb(218, 229, 236);
            checkBox1.Location = new Point(8, 167);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(211, 20);
            checkBox1.TabIndex = 6;
            checkBox1.Text = "Subscribe to Extravi on Youtube";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Font = new Font("Arial", 9.75F);
            checkBox2.ForeColor = Color.FromArgb(218, 229, 236);
            checkBox2.Location = new Point(8, 237);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(124, 20);
            checkBox2.TabIndex = 7;
            checkBox2.Text = "Visit reshade.me";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Font = new Font("Arial", 9.75F);
            checkBox3.ForeColor = Color.FromArgb(218, 229, 236);
            checkBox3.Location = new Point(8, 272);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(116, 20);
            checkBox3.TabIndex = 8;
            checkBox3.Text = "Visit extravi.dev";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Checked = true;
            checkBox4.CheckState = CheckState.Checked;
            checkBox4.Font = new Font("Arial", 9.75F);
            checkBox4.ForeColor = Color.FromArgb(218, 229, 236);
            checkBox4.Location = new Point(8, 202);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(157, 20);
            checkBox4.TabIndex = 9;
            checkBox4.Text = "Join our Discord server";
            checkBox4.UseVisualStyleBackColor = true;
            checkBox4.CheckedChanged += checkBox4_CheckedChanged;
            // 
            // UserControl3
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            BackColor = Color.FromArgb(17, 17, 17);
            Controls.Add(checkBox4);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label1);
            Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "UserControl3";
            Size = new Size(330, 360);
            Load += UserControl3_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Button button1;
        private Label label1;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
    }
}
