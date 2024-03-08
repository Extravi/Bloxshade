using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bloxshade
{
    public partial class UserControl5 : UserControl
    {
        public UserControl5()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 parentForm = (Form1)this.Parent;
            parentForm.userControl21.Hide();
            parentForm.userControl31.Hide();
            parentForm.userControl41.Hide();
            parentForm.userControl51.Hide();
            parentForm.userControl11.Show();
            parentForm.userControl11.BringToFront();
        }

        private void UserControl5_Load(object sender, EventArgs e)
        {

        }
        static void OpenUrlInDefaultBrowser(string url)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = $"/c start {url}",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            });
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenUrlInDefaultBrowser("https://github.com/Extravi/extravi.github.io");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenUrlInDefaultBrowser("https://github.com/crosire/reshade-shaders");
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenUrlInDefaultBrowser("https://github.com/CeeJayDK/SweetFX");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenUrlInDefaultBrowser("https://github.com/prod80/prod80-ReShade-Repository");
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenUrlInDefaultBrowser("https://github.com/Not-Smelly-Garbage/OldReshadeShaders");
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenUrlInDefaultBrowser("https://github.com/Fubaxiusz/fubax-shaders");
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenUrlInDefaultBrowser("https://github.com/Otakumouse/stormshade");
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 parentForm = (Form1)this.Parent;
            parentForm.userControl21.Hide();
            parentForm.userControl31.Hide();
            parentForm.userControl11.Hide();
            parentForm.userControl41.Hide();
            parentForm.userControl51.Hide();
            parentForm.userControl61.Show();
            parentForm.userControl61.BringToFront();
        }
    }
}
