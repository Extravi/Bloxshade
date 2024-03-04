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
    public partial class UserControl3 : UserControl
    {
        public UserControl3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<CheckBox, string> checkBoxUrls = new Dictionary<CheckBox, string>
            {
                { checkBox1, "https://www.youtube.com/channel/UCOZnRzWstxDLyW30TjWEevQ?sub_confirmation=1" },
                { checkBox2, "https://reshade.me/" },
                { checkBox3, "https://extravi.dev/" },
                { checkBox4, "https://discord.gg/TNG5yHsEwu" }
            };
            foreach (var checkBox in checkBoxUrls.Keys)
            {
                if (checkBox.Checked)
                {
                    OpenUrlInDefaultBrowser(checkBoxUrls[checkBox]);
                }
            }
            Application.Exit();
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

        private void UserControl3_Load(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
