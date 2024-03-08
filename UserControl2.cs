using System;
using System.IO;
using System.Net.Http;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO.Compression;

namespace Bloxshade
{
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void UserControl2_Load(object sender, EventArgs e)
        {

        }
        public async void Install()
        {
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

                // presets path
                string targetFolderNamePresets = "Custom";
                string nvidiaPresetsTargetFolderPath = Path.Combine(nvidiaFolderPath, targetFolderName, targetFolderNamePresets);

                // FXShaders
                string targetFolderNameFXShaders = "FXShaders";
                string nvidiaFXShadersTargetFolderPath = Path.Combine(nvidiaFolderPath, targetFolderName, targetFolderNameFXShaders);

                // ReShade Nvidia
                string ReShadeNvidia = "6b452c4a101ccb228c4986560a51c571473c517b.zip";
                string ReShadeNvidiaFilePath = Path.Combine(nvidiaTargetFolderPath, ReShadeNvidia);

                // SweetFX
                string SweetFX = "a792aee788c6203385a858ebdea82a77f81c67f0.zip";
                string SweetFXFilePath = Path.Combine(nvidiaTargetFolderPath, SweetFX);

                // NiceGuy
                string NiceGuy = "b81ce5699abcedaa889f044b6473f8569ab40570.zip";
                string NiceGuyFilePath = Path.Combine(nvidiaTargetFolderPath, NiceGuy);

                // Glamarye
                string Glamarye = "9dd9b826fa2cbea818ef1bc487e5f2e7f427c750.zip";
                string GlamaryeFilePath = Path.Combine(nvidiaTargetFolderPath, Glamarye);

                // AlucardDH
                string AlucardDH = "f3ca553f9012caced93f273890d20ea427865fd5.zip";
                string AlucardDHFilePath = Path.Combine(nvidiaTargetFolderPath, AlucardDH);

                // AstrayFX
                string AstrayFX = "910e3213a846b34dd65d94e84b61b61fca69dd6d.zip";
                string AstrayFXFilePath = Path.Combine(nvidiaTargetFolderPath, AstrayFX);

                // FXShaders
                string FXShaders = "76365e35c48e30170985ca371e67d8daf8eb9a98.zip";
                string FXShadersFilePath = Path.Combine(nvidiaTargetFolderPath, FXShaders);

                // prod80
                string prod80 = "1abde8e935ce60bd6def6fef849090c4e6b0a362.zip";
                string prod80FilePath = Path.Combine(nvidiaTargetFolderPath, prod80);

                // dependencies
                string dependencies = "dependencies.zip";
                string dependenciesFilePath = Path.Combine(nvidiaTargetFolderPath, dependencies);

                // ansel-presets
                string anselPresets = "ansel-presets.zip";
                string anselPresetsFilePath = Path.Combine(nvidiaTargetFolderPath, anselPresets);

                // reshade-shaders
                string reshadeshaders = "fb9dcb99034759cd437610b7657307d52f8086ff.zip";
                string reshadeshadersFilePath = Path.Combine(nvidiaTargetFolderPath, reshadeshaders);

                // reshade-shaders legacy
                string reshadeshaderslegacy = "1258f18337a1f186740a6c4cb747c1aa6f0d79a9.zip";
                string reshadeshaderslegacyFilePath = Path.Combine(nvidiaTargetFolderPath, reshadeshaderslegacy);

                // qUINT
                string qUINTshaders = "98fed77b26669202027f575a6d8f590426c21ebd.zip";
                string qUINTshadersFilePath = Path.Combine(nvidiaTargetFolderPath, qUINTshaders);

                // OldReshadeShaders
                string OldReshadeShadersshaders = "86772ee94877f82a97c49af05b8bca84d9065de7.zip";
                string OldReshadeShadersshadersshadersFilePath = Path.Combine(nvidiaTargetFolderPath, OldReshadeShadersshaders);

                // fubax-shaders
                string fubaxshadersshaders = "c83190dd11b26c75a51a1b452106c8d170771e28.zip";
                string fubaxshadersshadersshadersFilePath = Path.Combine(nvidiaTargetFolderPath, fubaxshadersshaders);

                // stormshade
                string stormshadeshaders = "6dad6589fe505e998b01295dc6c647b031386e74.zip";
                string stormshadeshadersshadersFilePath = Path.Combine(nvidiaTargetFolderPath, stormshadeshaders);

                // RobloxPlayerBeta
                string RobloxPlayerBeta = "RobloxPlayerBeta.zip";
                string RobloxPlayerBetaFilePath = Path.Combine(nvidiaTargetFolderPath, RobloxPlayerBeta);

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
                    richTextBox1.Text += "Bloxstrap installation found." + Environment.NewLine;
                    bloxstrapTrue = true;
                }
                else
                {
                    bloxstrapTrue = false;
                }

                // check for Roblox
                if (bloxstrapTrue == false)
                {
                    richTextBox1.Text += "Bloxstrap not found." + Environment.NewLine;
                    bool foundPlayerBetaInAppData = CheckForExecutable(robloxAppDataFolderPath, robloxPlayerBetaExecutable);
                    bool foundAnselInAppData = CheckForExecutable(robloxAppDataFolderPath, robloxAnselExecutable);
                    if (foundPlayerBetaInAppData || foundAnselInAppData)
                    {
                        // pass
                    }
                    else
                    {
                        richTextBox1.Text += "Roblox installation was not found, or we cannot install Bloxshade because Roblox is installed in Program Files. https://www.roblox.com/download/client" + Environment.NewLine;
                        // abort
                        return;
                    }
                }
                else
                {
                    // pass
                    // bloxstrap is true
                }

                // check for Ansel folder path
                if (Directory.Exists(nvidiaTargetFolderPath))
                {
                    richTextBox1.Text += "Ansel folder already exists; reinstalling." + Environment.NewLine;
                    // delete old Ansel folder and make a new one
                    Directory.Delete(nvidiaTargetFolderPath, true);
                    Directory.CreateDirectory(nvidiaTargetFolderPath);
                    Directory.CreateDirectory(nvidiaPresetsTargetFolderPath);
                    Directory.CreateDirectory(nvidiaFXShadersTargetFolderPath);
                }
                else
                {
                    richTextBox1.Text += "Ansel folder not found; proceeding to install ReShade FX shaders." + Environment.NewLine;
                    // make new folder Ansel
                    Directory.CreateDirectory(nvidiaTargetFolderPath);
                    Directory.CreateDirectory(nvidiaPresetsTargetFolderPath);
                    Directory.CreateDirectory(nvidiaFXShadersTargetFolderPath);
                }

                List<string> urls = new List<string>
                {
                    "https://github.com/CeeJayDK/SweetFX/archive/a792aee788c6203385a858ebdea82a77f81c67f0.zip",
                    "https://github.com/prod80/prod80-ReShade-Repository/archive/1abde8e935ce60bd6def6fef849090c4e6b0a362.zip",
                    "https://github.com/Extravi/extravi.github.io/raw/940ac7272c02ef564af3a65e54d0f3aa6df46034/update/dependencies.zip",
                    "https://github.com/crosire/reshade-shaders/archive/fb9dcb99034759cd437610b7657307d52f8086ff.zip",
                    "https://github.com/martymcmodding/qUINT/archive/98fed77b26669202027f575a6d8f590426c21ebd.zip",
                    "https://github.com/crosire/reshade-shaders/archive/1258f18337a1f186740a6c4cb747c1aa6f0d79a9.zip",
                    "https://github.com/Not-Smelly-Garbage/OldReshadeShaders/archive/86772ee94877f82a97c49af05b8bca84d9065de7.zip",
                    "https://github.com/Fubaxiusz/fubax-shaders/archive/c83190dd11b26c75a51a1b452106c8d170771e28.zip",
                    "https://github.com/Otakumouse/stormshade/archive/6dad6589fe505e998b01295dc6c647b031386e74.zip",
                    "https://github.com/mj-ehsan/NiceGuy-Shaders/archive/b81ce5699abcedaa889f044b6473f8569ab40570.zip",
                    "https://github.com/rj200/Glamarye_Fast_Effects_for_ReShade/archive/9dd9b826fa2cbea818ef1bc487e5f2e7f427c750.zip",
                    "https://github.com/AlucardDH/dh-reshade-shaders/archive/f3ca553f9012caced93f273890d20ea427865fd5.zip",
                    "https://github.com/BlueSkyDefender/AstrayFX/archive/910e3213a846b34dd65d94e84b61b61fca69dd6d.zip",
                    "https://github.com/luluco250/FXShaders/archive/76365e35c48e30170985ca371e67d8daf8eb9a98.zip",
                    "https://github.com/crosire/reshade-shaders/archive/6b452c4a101ccb228c4986560a51c571473c517b.zip",
                    "https://github.com/Extravi/extravi.github.io/raw/main/update/ansel-presets.zip",
                    "https://github.com/Extravi/bloxshade-args/releases/latest/download/RobloxPlayerBeta.zip",
                };

                foreach (string url in urls)
                {
                    await DownloadFileAsync(url, nvidiaTargetFolderPath);
                }

                // downloaded files
                richTextBox1.Text += "All downloads completed successfully." + Environment.NewLine;

                (string FilePath, string Comment)[] filesToExtractAndDelete = {
                    (OldReshadeShadersshadersshadersFilePath, "// OldReshadeShaders"),
                    (fubaxshadersshadersshadersFilePath, "// fubax-shaders"),
                    (stormshadeshadersshadersFilePath, "// stormshade"),
                    (qUINTshadersFilePath, "// qUINT"),
                    (reshadeshadersFilePath, "// reshade-shaders"),
                    (reshadeshaderslegacyFilePath, "// reshade-shaders legacy"),
                    (SweetFXFilePath, "// SweetFX"),
                    (ReShadeNvidiaFilePath, "// ReShade Nvidia"),
                    (NiceGuyFilePath, "// NiceGuy"),
                    (GlamaryeFilePath, "// Glamarye"),
                    (AlucardDHFilePath, "// AlucardDH"),
                    (AstrayFXFilePath, "// AstrayFX"),
                    (FXShadersFilePath, "// FXShaders"),
                    (prod80FilePath, "// prod80"),
                    (dependenciesFilePath, "// dependencies"),
                    (anselPresetsFilePath, "// ansel-presets"),
                    (RobloxPlayerBetaFilePath, "// RobloxPlayerBeta")
                };

                foreach (var fileInfo in filesToExtractAndDelete)
                {
                    string fileName = Path.GetFileName(fileInfo.FilePath);
                    richTextBox1.Text += $"Extracting and deleting: {fileName} {fileInfo.Comment}" + Environment.NewLine;
                    ZipFile.ExtractToDirectory(fileInfo.FilePath, nvidiaTargetFolderPath);
                    File.Delete(fileInfo.FilePath);
                }

                // qUINT
                string qUINTExtractedFolderPath = Path.Combine(nvidiaTargetFolderPath, "qUINT-98fed77b26669202027f575a6d8f590426c21ebd");
                string qUINTFolderPath = Path.Combine(qUINTExtractedFolderPath, "Shaders");

                // reshade-shaders
                string reshadeshadersExtractedFolderPath = Path.Combine(nvidiaTargetFolderPath, "reshade-shaders-fb9dcb99034759cd437610b7657307d52f8086ff");
                string reshadeshadersshadersFolderPath = Path.Combine(reshadeshadersExtractedFolderPath, "Shaders");
                string reshadeshaderstexturesFolderPath = Path.Combine(reshadeshadersExtractedFolderPath, "Textures");

                // OldReshadeShaders
                string OldReshadeShadersExtractedFolderPath = Path.Combine(nvidiaTargetFolderPath, "OldReshadeShaders-86772ee94877f82a97c49af05b8bca84d9065de7");
                string OldReshadeShadersshadersFolderPath = Path.Combine(OldReshadeShadersExtractedFolderPath, "Shaders");
                string OldReshadeShaderstexturesFolderPath = Path.Combine(OldReshadeShadersExtractedFolderPath, "Textures");

                // fubax-shaders
                string fubaxshadersExtractedFolderPath = Path.Combine(nvidiaTargetFolderPath, "fubax-shaders-c83190dd11b26c75a51a1b452106c8d170771e28");
                string fubaxshadersshadersFolderPath = Path.Combine(fubaxshadersExtractedFolderPath, "Shaders");
                string fubaxshaderstexturesFolderPath = Path.Combine(fubaxshadersExtractedFolderPath, "Textures");

                // stormshade
                string stormshadeExtractedFolderPath = Path.Combine(nvidiaTargetFolderPath, "stormshade-6dad6589fe505e998b01295dc6c647b031386e74");
                string stormshadeshadersFolderPath = Path.Combine(stormshadeExtractedFolderPath, "v4.X\\reshade-shaders\\Shader Library\\Recommended");
                string stormshadeshadersFolderPathReShade = Path.Combine(stormshadeExtractedFolderPath, "v4.X\\reshade-shaders\\Shaders");
                string stormshadetexturesFolderPath = Path.Combine(stormshadeExtractedFolderPath, "v4.X\\reshade-shaders\\Textures");

                // reshade-shaders legacy
                string reshadeshaderslegacyExtractedFolderPath = Path.Combine(nvidiaTargetFolderPath, "reshade-shaders-1258f18337a1f186740a6c4cb747c1aa6f0d79a9");
                string reshadeshaderslegacyshadersFolderPath = Path.Combine(reshadeshaderslegacyExtractedFolderPath, "Shaders");
                string reshadeshaderslegacytexturesFolderPath = Path.Combine(reshadeshaderslegacyExtractedFolderPath, "Textures");

                // SweetFX
                string sweetFXExtractedFolderPath = Path.Combine(nvidiaTargetFolderPath, "SweetFX-a792aee788c6203385a858ebdea82a77f81c67f0");
                string SweetFXTshadersFolderPath = Path.Combine(sweetFXExtractedFolderPath, "Shaders");
                string SweetFXTtexturesFolderPath = Path.Combine(sweetFXExtractedFolderPath, "Textures");

                // ReShade Nvidia
                string ReShadeNvidiaExtractedFolderPath = Path.Combine(nvidiaTargetFolderPath, "reshade-shaders-6b452c4a101ccb228c4986560a51c571473c517b");
                string ReShadeNvidiashadersFolderPath = Path.Combine(ReShadeNvidiaExtractedFolderPath, "ShadersAndTextures");

                // NiceGuy
                string NiceGuyExtractedFolderPath = Path.Combine(nvidiaTargetFolderPath, "NiceGuy-Shaders-b81ce5699abcedaa889f044b6473f8569ab40570");
                string NiceGuyshadersFolderPath = Path.Combine(NiceGuyExtractedFolderPath, "Shaders");
                string NiceGuytexturesFolderPath = Path.Combine(NiceGuyExtractedFolderPath, "Textures");

                // Glamarye
                string GlamaryeExtractedFolderPath = Path.Combine(nvidiaTargetFolderPath, "Glamarye_Fast_Effects_for_ReShade-9dd9b826fa2cbea818ef1bc487e5f2e7f427c750");
                string GlamaryeshadersFolderPath = Path.Combine(GlamaryeExtractedFolderPath, "Shaders");

                // AlucardDH
                string AlucardDHExtractedFolderPath = Path.Combine(nvidiaTargetFolderPath, "dh-reshade-shaders-f3ca553f9012caced93f273890d20ea427865fd5");
                string AlucardDHshadersFolderPath = Path.Combine(AlucardDHExtractedFolderPath, "Shaders");
                string AlucardDHtexturesFolderPath = Path.Combine(AlucardDHExtractedFolderPath, "Textures");

                // AstrayFX
                string AstrayFXExtractedFolderPath = Path.Combine(nvidiaTargetFolderPath, "AstrayFX-910e3213a846b34dd65d94e84b61b61fca69dd6d");
                string AstrayFXshadersFolderPath = Path.Combine(AstrayFXExtractedFolderPath, "Shaders");

                // FXShaders
                string FXShadersExtractedFolderPath = Path.Combine(nvidiaTargetFolderPath, "FXShaders-76365e35c48e30170985ca371e67d8daf8eb9a98");
                string FXShadersshadersFolderPath = Path.Combine(FXShadersExtractedFolderPath, "Shaders");
                string FXShadersFXShadersshadersFolderPath = Path.Combine(FXShadersExtractedFolderPath, "Shaders\\FXShaders");
                string FXShaderstexturesFolderPath = Path.Combine(FXShadersExtractedFolderPath, "Textures");

                // prod80
                string prod80ExtractedFolderPath = Path.Combine(nvidiaTargetFolderPath, "prod80-ReShade-Repository-1abde8e935ce60bd6def6fef849090c4e6b0a362");
                string prod80TshadersFolderPath = Path.Combine(prod80ExtractedFolderPath, "Shaders");
                string prod80TtexturesFolderPath = Path.Combine(prod80ExtractedFolderPath, "Textures");

                // ansel-presets
                string anselPresetsExtractedFolderPath = Path.Combine(nvidiaTargetFolderPath, "ansel-presets");

                // move textures and shaders
                // move files
                void MoveFilesToTargetFolder(string[] sourcePaths, string targetFolderPath)
                {
                    foreach (string filePath in sourcePaths)
                    {
                        string fileName = Path.GetFileName(filePath);
                        string targetFilePath = Path.Combine(targetFolderPath, fileName);

                        if (!File.Exists(targetFilePath))
                        {
                            File.Move(filePath, targetFilePath);
                            richTextBox1.Text += $"Moved file: {fileName}" + Environment.NewLine;
                        }
                        else
                        {
                            richTextBox1.Text += $"Skipped file (already exists): {fileName}" + Environment.NewLine;
                        }
                    }
                }

                Dictionary<string, string> folders = new Dictionary<string, string>()
                {
                    { ReShadeNvidiashadersFolderPath, "ReShade Nvidia" },
                    { SweetFXTtexturesFolderPath, "SweetFX" },
                    { SweetFXTshadersFolderPath, "SweetFX shaders" },
                    { prod80TtexturesFolderPath, "prod80 textures" },
                    { prod80TshadersFolderPath, "prod80 shaders" },
                    { reshadeshadersshadersFolderPath, "reshade-shaders shaders" },
                    { reshadeshaderstexturesFolderPath, "reshade-shaders textures" },
                    { qUINTFolderPath, "qUINT shaders" },
                    { reshadeshaderslegacyshadersFolderPath, "reshade-shaders shaders legacy" },
                    { reshadeshaderslegacytexturesFolderPath, "reshade-shaders textures legacy" },
                    { OldReshadeShadersshadersFolderPath, "OldReshadeShaders shaders" },
                    { OldReshadeShaderstexturesFolderPath, "OldReshadeShaders textures" },
                    { fubaxshadersshadersFolderPath, "fubax-shaders shaders" },
                    { fubaxshaderstexturesFolderPath, "fubax-shaders textures" },
                    { stormshadetexturesFolderPath, "stormshade textures" },
                    { stormshadeshadersFolderPath, "stormshade shaders" },
                    { stormshadeshadersFolderPathReShade, "stormshade ReShade shaders" },
                    { NiceGuyshadersFolderPath, "NiceGuy shaders" },
                    { NiceGuytexturesFolderPath, "NiceGuy textures" },
                    { GlamaryeshadersFolderPath, "Glamarye shaders" },
                    { AlucardDHshadersFolderPath, "AlucardDH shaders" },
                    { AlucardDHtexturesFolderPath, "AlucardDH textures" },
                    { AstrayFXshadersFolderPath, "AstrayFX shaders" },
                    { FXShadersshadersFolderPath, "FXShaders shaders" },
                    { FXShaderstexturesFolderPath, "FXShaders textures" }
                };

                foreach (KeyValuePair<string, string> folder in folders)
                {
                    MoveFilesToTargetFolder(Directory.GetFiles(folder.Key), nvidiaTargetFolderPath);
                }

                MoveFilesToTargetFolder(Directory.GetFiles(FXShadersFXShadersshadersFolderPath), nvidiaFXShadersTargetFolderPath); // FXShaders reshade shaders

                MoveFilesToTargetFolder(Directory.GetFiles(anselPresetsExtractedFolderPath), nvidiaPresetsTargetFolderPath); // ansel-presets

                // cleanup
                richTextBox1.Text += $"Removing unused folders." + Environment.NewLine;
                string[] foldersToDelete = {
                    sweetFXExtractedFolderPath,
                    prod80ExtractedFolderPath,
                    reshadeshadersExtractedFolderPath,
                    qUINTExtractedFolderPath,
                    reshadeshaderslegacyExtractedFolderPath,
                    OldReshadeShadersExtractedFolderPath,
                    fubaxshadersExtractedFolderPath,
                    stormshadeExtractedFolderPath,
                    NiceGuyExtractedFolderPath,
                    GlamaryeExtractedFolderPath,
                    AlucardDHExtractedFolderPath,
                    AstrayFXExtractedFolderPath,
                    FXShadersExtractedFolderPath,
                    ReShadeNvidiaExtractedFolderPath,
                    anselPresetsExtractedFolderPath
                };

                foreach (string folderPath in foldersToDelete)
                {
                    richTextBox1.Text += $"Removing folder: {Path.GetFileName(folderPath)}" + Environment.NewLine;
                    Directory.Delete(folderPath, true);
                }

                // cleanup problematic shaders
                File.Delete(Path.Combine(nvidiaTargetFolderPath, "DOF.fx"));

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
                    }
                }


                // debug code
                //return;
                Form1 parentForm = (Form1)this.Parent;
                parentForm.userControl21.Hide();
                parentForm.userControl41.Hide();
                parentForm.userControl51.Hide();
                parentForm.userControl31.Show();
                parentForm.userControl31.BringToFront();
            }

            async Task DownloadFileAsync(string url, string targetFolderPath)
            {
                string fileName = GetFileNameFromUrl(url);
                string outputPath = Path.Combine(targetFolderPath, fileName);

                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        // send request
                        byte[] fileBytes = await client.GetByteArrayAsync(url);
                        // save the file
                        File.WriteAllBytes(outputPath, fileBytes);
                        richTextBox1.Text += $"Downloaded {fileName} successfully." + Environment.NewLine;
                    }
                    catch (HttpRequestException ex)
                    {
                        richTextBox1.Text += $"Error downloading {fileName}: {ex.Message}" + Environment.NewLine;
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

                            richTextBox1.Text += ($"Found {executableName} in: {subDirectory.FullName}" + Environment.NewLine);

                            // rename the file
                            string newExecutablePath = Path.Combine(subDirectory.FullName, "eurotrucks2.exe");
                            if (File.Exists(newExecutablePath))
                            {
                                richTextBox1.Text += "Destination file already exists. Skipping..." + Environment.NewLine;
                            }
                            else
                            {
                                try
                                {
                                    File.Move(executablePath, newExecutablePath);
                                }
                                catch (IOException ex)
                                {
                                    richTextBox1.Text += $"Error moving file: {ex.Message}" + Environment.NewLine;
                                }
                            }
                            return true;
                        }
                    }
                }
                return false;
            }

            static string GetFileNameFromUrl(string url)
            {
                // get file name
                Uri uri = new Uri(url);
                return Path.GetFileName(uri.LocalPath);
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
        }
    }
}
