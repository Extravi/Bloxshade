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
    public partial class UserControl6 : UserControl
    {
        public UserControl6()
        {
            InitializeComponent();
        }

        private void UserControl6_Load(object sender, EventArgs e)
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
            OpenUrlInDefaultBrowser("https://github.com/mj-ehsan/NiceGuy-Shaders");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenUrlInDefaultBrowser("https://github.com/rj200/Glamarye_Fast_Effects_for_ReShade");
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenUrlInDefaultBrowser("https://github.com/AlucardDH/dh-reshade-shaders");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenUrlInDefaultBrowser("https://github.com/BlueSkyDefender/AstrayFX");
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenUrlInDefaultBrowser("https://github.com/luluco250/FXShaders");
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
