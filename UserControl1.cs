using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bloxshade
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 parentForm = (Form1)this.Parent;
            parentForm.userControl11.Hide();
            parentForm.userControl41.Hide();
            parentForm.userControl51.Hide();
            parentForm.userControl21.Show();
            parentForm.userControl21.BringToFront();
            parentForm.userControl21.Install();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 parentForm = (Form1)this.Parent;
            parentForm.userControl21.Hide();
            parentForm.userControl31.Hide();
            parentForm.userControl11.Hide();
            parentForm.userControl51.Show();
            parentForm.userControl41.Show();
            parentForm.userControl41.BringToFront();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 parentForm = (Form1)this.Parent;
            parentForm.userControl21.Hide();
            parentForm.userControl31.Hide();
            parentForm.userControl11.Hide();
            parentForm.userControl41.Hide();
            parentForm.userControl61.Hide();
            parentForm.userControl51.Show();
            parentForm.userControl51.BringToFront();
        }
    }
}
