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
            parentForm.userControl51.Hide();
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

            // Bloxstrap path
            string bloxstrapAppDataFolderPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Bloxstrap",
                "Versions"
            );

            // Nvidia path
            string nvidiaFolderPath = @"C:\Program Files\NVIDIA Corporation";
            string targetFolderName = "Ansel";
            string nvidiaTargetFolderPath = Path.Combine(nvidiaFolderPath, targetFolderName);

            // check the Roblox folder path
            string robloxPlayerBetaExecutable = "RobloxPlayerBeta.exe";
            string robloxAnselExecutable = "eurotrucks2.exe";

            // bloxstrap install
            var bloxstrapTrue = false;

            // check for Bloxstrap
            bool foundBloxstrapPlayerBetaInAppData = CheckForExecutable(bloxstrapAppDataFolderPath, robloxPlayerBetaExecutable);
            bool foundBloxstrapAnselInAppData = CheckForExecutable(bloxstrapAppDataFolderPath, robloxAnselExecutable);

            if (foundBloxstrapPlayerBetaInAppData || foundBloxstrapAnselInAppData)
            {
                bloxstrapTrue = true;
            }
            else
            {
                bloxstrapTrue = false;
            }

            // check for Roblox
            if (bloxstrapTrue == false)
            {
                bool foundPlayerBetaInAppData = CheckForExecutable(robloxAppDataFolderPath, robloxPlayerBetaExecutable);
                bool foundAnselInAppData = CheckForExecutable(robloxAppDataFolderPath, robloxAnselExecutable);
                if (foundPlayerBetaInAppData || foundAnselInAppData)
                {
                    // pass
                }
                else
                {
                    MessageBox.Show("Bloxshade cannot locate Roblox on this system.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // abort
                    return;
                }
            }
            else
            {
                // pass
                // bloxstrap is true
            }

            // RobloxPlayerBeta file path
            string anselPath = null;
            string RobloxPlayerBetaExtractedFolderPath = Path.Combine(nvidiaTargetFolderPath, "RobloxPlayerBeta.exe");
            if (bloxstrapTrue == true)
            {
                if ((anselPath = CheckForAnsel(bloxstrapAppDataFolderPath, robloxAnselExecutable)) != null)
                {
                    string destinationFilePath = Path.Combine(anselPath, "RobloxPlayerBeta.exe");
                    if (File.Exists(destinationFilePath))
                    {
                        File.Delete(destinationFilePath);
                    }
                    File.Copy(RobloxPlayerBetaExtractedFolderPath, destinationFilePath);
                    MessageBox.Show("Bloxstrap has been updated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // add it for roblox
                if ((anselPath = CheckForAnsel(robloxAppDataFolderPath, robloxAnselExecutable)) != null)
                {
                    string destinationFilePath = Path.Combine(anselPath, "RobloxPlayerBeta.exe");
                    if (File.Exists(destinationFilePath))
                    {
                        File.Delete(destinationFilePath);
                    }
                    File.Copy(RobloxPlayerBetaExtractedFolderPath, destinationFilePath);
                    MessageBox.Show("Roblox has been updated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
                        anselPath = versionFolder.FullName;
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
                        if (executablePath.Contains("C:\\Program Files (x86)\\Roblox\\Versions"))
                        {
                            continue; // skip executable
                        }

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

        private void UserControl4_Load(object sender, EventArgs e)
        {

        }
    }
}
