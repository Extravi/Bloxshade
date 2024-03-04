using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Bloxshade
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("DwmApi")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);

        protected override void OnHandleCreated(EventArgs e)
        {
            if (DwmSetWindowAttribute(Handle, 19, new[] { 1 }, 4) != 0)
                DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Roblox path
            string robloxAppDataFolderPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Roblox",
                "Versions"
            );
            string robloxProgramFilesFolderPath = @"C:\Program Files (x86)\Roblox\Versions";

            string robloxAnselExecutable = "eurotrucks2.exe";
            string anselPath = null;

            // check for ansel only
            if ((anselPath = CheckForAnsel(robloxAppDataFolderPath, robloxAnselExecutable)) != null)
            {
                // install found
            }
            else if ((anselPath = CheckForAnsel(robloxProgramFilesFolderPath, robloxAnselExecutable)) != null)
            {
                // install found
            }
            else
            {
                userControl21.Hide();
                userControl31.Hide();
                userControl41.Hide();
                userControl11.Show();
                userControl11.BringToFront();
            }
        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void userControl31_Load(object sender, EventArgs e)
        {

        }

        private void userControl21_Load(object sender, EventArgs e)
        {

        }
        static string CheckForAnsel(string folderPath, string executableName)
        {
            string anselPath = null;

            if (Directory.Exists(folderPath))
            {
                string[] versionFolders = Directory.GetDirectories(folderPath);
                foreach (string versionFolder in versionFolders)
                {
                    string executablePath = Path.Combine(versionFolder, executableName);
                    if (File.Exists(executablePath))
                    {
                        anselPath = executablePath;
                        break;
                    }
                }
            }

            return anselPath;
        }
    }
}
