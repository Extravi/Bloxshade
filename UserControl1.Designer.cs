﻿namespace Bloxshade
{
    partial class UserControl1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl1));
            label1 = new Label();
            button1 = new Button();
            label2 = new Label();
            linkLabel1 = new LinkLabel();
            linkLabel2 = new LinkLabel();
            SuspendLayout();
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
            label1.TabIndex = 0;
            label1.Text = "Bloxshade - Improve Roblox\r\nwith shaders.";
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
            button1.TabIndex = 1;
            button1.Text = "Install";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(218, 229, 236);
            label2.Location = new Point(8, 67);
            label2.MinimumSize = new Size(296, 48);
            label2.Name = "label2";
            label2.Size = new Size(296, 208);
            label2.TabIndex = 2;
            label2.Text = resources.GetString("label2.Text");
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = Color.FromArgb(138, 180, 248);
            linkLabel1.AutoSize = true;
            linkLabel1.Cursor = Cursors.Hand;
            linkLabel1.DisabledLinkColor = Color.FromArgb(138, 180, 248);
            linkLabel1.LinkBehavior = LinkBehavior.HoverUnderline;
            linkLabel1.LinkColor = Color.FromArgb(138, 180, 248);
            linkLabel1.Location = new Point(8, 330);
            linkLabel1.MinimumSize = new Size(52, 15);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(52, 15);
            linkLabel1.TabIndex = 7;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Settings";
            linkLabel1.VisitedLinkColor = Color.FromArgb(138, 180, 248);
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // linkLabel2
            // 
            linkLabel2.ActiveLinkColor = Color.FromArgb(138, 180, 248);
            linkLabel2.AutoSize = true;
            linkLabel2.Cursor = Cursors.Hand;
            linkLabel2.DisabledLinkColor = Color.FromArgb(138, 180, 248);
            linkLabel2.LinkBehavior = LinkBehavior.HoverUnderline;
            linkLabel2.LinkColor = Color.FromArgb(138, 180, 248);
            linkLabel2.Location = new Point(66, 330);
            linkLabel2.MinimumSize = new Size(115, 15);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(115, 15);
            linkLabel2.TabIndex = 8;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Acknowledgements";
            linkLabel2.VisitedLinkColor = Color.FromArgb(138, 180, 248);
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // UserControl1
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            BackColor = Color.FromArgb(17, 17, 17);
            Controls.Add(linkLabel2);
            Controls.Add(linkLabel1);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label1);
            Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "UserControl1";
            Size = new Size(330, 360);
            Load += UserControl1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Label label2;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
    }
}
