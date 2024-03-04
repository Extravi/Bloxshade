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
    public partial class UserControl4 : UserControl
    {
        public UserControl4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 parentForm = (Form1)this.Parent;
            parentForm.userControl21.Hide();
            parentForm.userControl31.Hide();
            parentForm.userControl41.Hide();
            parentForm.userControl11.Show();
            parentForm.userControl11.BringToFront();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenUrlInDefaultBrowser("https://discord.gg/TNG5yHsEwu");
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

        private void button1_Click(object sender, EventArgs e)
        {
            // Roblox path
            string robloxAppDataFolderPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Roblox",
                "Versions"
            );
            string robloxProgramFilesFolderPath = @"C:\Program Files (x86)\Roblox\Versions";

            // check the Roblox folder path
            string robloxPlayerBetaExecutable = "RobloxPlayerBeta.exe";
            string robloxAnselExecutable = "eurotrucks2.exe";
            string anselPath = null;

            bool foundPlayerBetaInAppData = CheckForExecutable(robloxAppDataFolderPath, robloxPlayerBetaExecutable);
            bool foundPlayerBetaInProgramFiles = CheckForExecutable(robloxProgramFilesFolderPath, robloxPlayerBetaExecutable);

            bool foundAnselInAppData = CheckForExecutable(robloxAppDataFolderPath, robloxAnselExecutable);
            bool foundAnselInProgramFiles = CheckForExecutable(robloxProgramFilesFolderPath, robloxAnselExecutable);

            if (foundPlayerBetaInAppData || foundPlayerBetaInProgramFiles || foundAnselInAppData || foundAnselInProgramFiles)
            {
                // check for ansel only
                if ((anselPath = CheckForAnsel(robloxAppDataFolderPath, robloxAnselExecutable)) != null)
                {
                    CreateShortcut(anselPath);
                    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                    string shortcutPath = Path.Combine(desktopPath, "Roblox with Nvidia Ansel.symlink");
                    MessageBox.Show(shortcutPath + " Roblox was renamed and shortcuts were successfully created; please start Roblox using those shortcuts.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if ((anselPath = CheckForAnsel(robloxProgramFilesFolderPath, robloxAnselExecutable)) != null)
                {
                    CreateShortcut(anselPath);
                    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                    string shortcutPath = Path.Combine(desktopPath, "Roblox with Nvidia Ansel.symlink");
                    MessageBox.Show(shortcutPath + " Roblox was renamed and shortcuts were successfully created; please start Roblox using those shortcuts.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // pass
                }
            }
            else
            {
                MessageBox.Show("Bloxshade cannot locate Roblox on this system.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        static string CheckForAnsel(string folderPath, string executableName)
        {
            string anselPath = null;

            if (Directory.Exists(folderPath))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
                DirectoryInfo[] versionFolders = directoryInfo.GetDirectories().OrderByDescending(f => f.LastWriteTime).ToArray();

                foreach (DirectoryInfo versionFolder in versionFolders)
                {
                    string executablePath = Path.Combine(versionFolder.FullName, executableName);
                    if (File.Exists(executablePath))
                    {
                        anselPath = executablePath;
                        break;
                    }
                }
            }

            return anselPath;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Nvidia path
            string nvidiaFolderPath = @"C:\Program Files\NVIDIA Corporation";
            string targetFolderName = "Ansel";
            string nvidiaTargetFolderPath = Path.Combine(nvidiaFolderPath, targetFolderName);

            // presets path
            string targetFolderNamePresets = "Custom";
            string nvidiaPresetsTargetFolderPath = Path.Combine(nvidiaFolderPath, targetFolderName, targetFolderNamePresets);

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // only show .ini files
            openFileDialog1.Filter = "INI Files|*.ini";
            openFileDialog1.Title = "Import your own Ansel preset";
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                // file path
                string selectedFilePath = openFileDialog1.FileName;
                string fileName = Path.GetFileName(selectedFilePath);
                string destinationFilePath = Path.Combine(nvidiaPresetsTargetFolderPath, fileName);

                if (File.Exists(destinationFilePath))
                {
                    // replace old file if it already exist
                    File.Delete(destinationFilePath);
                    File.Copy(selectedFilePath, destinationFilePath);
                    MessageBox.Show(selectedFilePath + " has been updated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // import the preset
                    File.Copy(selectedFilePath, destinationFilePath);
                    MessageBox.Show(selectedFilePath + " has been imported successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        bool CheckForExecutable(string folderPath, string executableName)
        {
            if (Directory.Exists(folderPath))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
                DirectoryInfo[] subDirectories = directoryInfo.GetDirectories().OrderByDescending(d => d.LastWriteTime).ToArray();

                foreach (DirectoryInfo subDirectory in subDirectories)
                {
                    string executablePath = Path.Combine(subDirectory.FullName, executableName);
                    if (File.Exists(executablePath))
                    {
                        // pass

                        // rename the file
                        string newExecutablePath = Path.Combine(subDirectory.FullName, "eurotrucks2.exe");
                        if (File.Exists(newExecutablePath))
                        {
                            // pass
                        }
                        else
                        {
                            try
                            {
                                File.Move(executablePath, newExecutablePath);
                            }
                            catch (IOException ex)
                            {
                                // pass
                            }
                        }
                        return true;
                    }
                }
            }
            return false;
        }

        static void CreateShortcut(string anselPath)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string shortcutPath = Path.Combine(desktopPath, "Roblox with Nvidia Ansel.symlink");

            if (File.Exists(shortcutPath))
            {
                File.Delete(shortcutPath);
            }

            string targetPath = "\"" + anselPath + "\"";
            string arguments = $"/c mklink \"{shortcutPath}\" {targetPath}";

            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = arguments,
                UseShellExecute = false,
                CreateNoWindow = true
            });
        }

        private void UserControl4_Load(object sender, EventArgs e)
        {

        }
    }
}
