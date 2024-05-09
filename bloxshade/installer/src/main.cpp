// Description: Bloxshade installer source code.
// Author: Dante (dante@extravi.dev)
// Date: 2024-05-08

#include <iostream>
#include <fstream>
#include <string>
#include <cstring>
#include <Windows.h>
#include <shellapi.h>

#include "json.hpp"

using json = nlohmann::json;

// namespace for fs
namespace fs = std::filesystem;

// variables 
char value[MAX_PATH];
DWORD valueSize = sizeof(value);
bool bloxstrap = false;
bool list = false;
std::string bloxstrapPath;
std::string roPath;
std::string defaultPath;
std::vector<std::string> file_names;
// args
bool import = false;
bool shortcutarg = false;
bool fix = false;
std::wstring url;
std::string userPreset;
bool install = false;

// nvidia paths
const std::string anselPath = "C:\\Program Files\\NVIDIA Corporation\\Ansel";
const std::string presetsPath = "C:\\Program Files\\NVIDIA Corporation\\Ansel\\Custom";
const std::string shadersPath = "C:\\Program Files\\NVIDIA Corporation\\Ansel\\FXShaders";

// install file
const std::string installtxt = "C:\\Program Files\\Bloxshade\\install.txt";

// redirect std::cout to the install file
void output() {
    static std::ofstream installFile(installtxt, std::ios::app);
    static std::streambuf* coutBuffer = std::cout.rdbuf();
    std::cout.rdbuf(installFile.rdbuf());
}

// urls
std::vector<std::string> urls = {
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
    "https://github.com/Extravi/ansel-shaders/archive/c286b39f3dc680c6c98f154f512a5109e213aa67.zip",
    "https://github.com/bituq/ZealShaders/archive/e4753908efda49d5423f4e0395161608c9207e2e.zip",
    "https://github.com/Fubaxiusz/fubax-shaders-dev/archive/023c080ac489fbe09b1c8e2975eaee340d7a0745.zip"
};

//file paths
std::vector<std::string> paths = {
    "\\reshade-shaders-6b452c4a101ccb228c4986560a51c571473c517b\\ShadersAndTextures", // ReShade Nvidia
    "\\SweetFX-a792aee788c6203385a858ebdea82a77f81c67f0\\Shaders", // SweetFX
    "\\SweetFX-a792aee788c6203385a858ebdea82a77f81c67f0\\Textures",
    "\\prod80-ReShade-Repository-1abde8e935ce60bd6def6fef849090c4e6b0a362\\Shaders", // prod80
    "\\prod80-ReShade-Repository-1abde8e935ce60bd6def6fef849090c4e6b0a362\\Textures",
    "\\reshade-shaders-fb9dcb99034759cd437610b7657307d52f8086ff\\Shaders", // ReShade Shaders
    "\\reshade-shaders-fb9dcb99034759cd437610b7657307d52f8086ff\\Textures",
    "\\qUINT-98fed77b26669202027f575a6d8f590426c21ebd\\Shaders", // qUINT
    "\\reshade-shaders-1258f18337a1f186740a6c4cb747c1aa6f0d79a9\\Shaders", // ReShade legacy
    "\\reshade-shaders-1258f18337a1f186740a6c4cb747c1aa6f0d79a9\\Textures",
    "\\OldReshadeShaders-86772ee94877f82a97c49af05b8bca84d9065de7\\Shaders", // Old ReShade Shaders
    "\\OldReshadeShaders-86772ee94877f82a97c49af05b8bca84d9065de7\\Textures",
    "\\fubax-shaders-c83190dd11b26c75a51a1b452106c8d170771e28\\Shaders", // fubax Shaders
    "\\fubax-shaders-c83190dd11b26c75a51a1b452106c8d170771e28\\Textures",
    "\\stormshade-6dad6589fe505e998b01295dc6c647b031386e74\\v4.X\\reshade-shaders\\Shader Library\\Recommended", // stormshade
    "\\stormshade-6dad6589fe505e998b01295dc6c647b031386e74\\v4.X\\reshade-shaders\\Shaders",
    "\\stormshade-6dad6589fe505e998b01295dc6c647b031386e74\\v4.X\\reshade-shaders\\Textures",
    "\\NiceGuy-Shaders-b81ce5699abcedaa889f044b6473f8569ab40570\\Shaders", // NiceGuy
    "\\NiceGuy-Shaders-b81ce5699abcedaa889f044b6473f8569ab40570\\Textures",
    "\\Glamarye_Fast_Effects_for_ReShade-9dd9b826fa2cbea818ef1bc487e5f2e7f427c750\\Shaders", // Glamarye
    "\\dh-reshade-shaders-f3ca553f9012caced93f273890d20ea427865fd5\\Shaders", // AlucardDH
    "\\dh-reshade-shaders-f3ca553f9012caced93f273890d20ea427865fd5\\Textures",
    "\\AstrayFX-910e3213a846b34dd65d94e84b61b61fca69dd6d\\Shaders", // AstrayFX
    "\\FXShaders-76365e35c48e30170985ca371e67d8daf8eb9a98\\Shaders", // FXShaders
    "\\FXShaders-76365e35c48e30170985ca371e67d8daf8eb9a98\\Textures",
    "\\ansel-shaders-c286b39f3dc680c6c98f154f512a5109e213aa67\\cMotionBlur", // Extravi shader archive
    "\\ansel-shaders-c286b39f3dc680c6c98f154f512a5109e213aa67\\Zeal_RimLight",
    "\\ZealShaders-e4753908efda49d5423f4e0395161608c9207e2e\\Shaders", // ZealShaders
    "\\fubax-shaders-dev-023c080ac489fbe09b1c8e2975eaee340d7a0745\\Shaders", // fubax Shaders dev
    "\\fubax-shaders-dev-023c080ac489fbe09b1c8e2975eaee340d7a0745\\Textures"
};

// download files
std::string extractFileName(const std::string& url) {
    // last '/' in the url for the file name
    size_t found = url.find_last_of("/");

    // return file name
    return url.substr(found + 1);
}

void downloadFile(const std::string& url, const std::string& outputDirectory, bool list, bool install) {
    // file path and name
    std::string fileName = url.substr(url.find_last_of('/') + 1);
    std::string outputPath = outputDirectory + "\\" + fileName;

    // convert narrow-character strings to wide-character strings
    std::wstring wOutputPath(outputPath.begin(), outputPath.end());
    std::wstring wCommand = L"C:\\Windows\\System32\\WindowsPowerShell\\v1.0\\powershell.exe -Command \"$ProgressPreference = 'SilentlyContinue'; Invoke-WebRequest -Uri '" + std::wstring(url.begin(), url.end()) + L"' -OutFile '" + wOutputPath + L"'\"";

    // command to download the file
    std::cout << "Downloading: " << fileName << std::endl;

    // create process parameters
    STARTUPINFOW si = { sizeof(STARTUPINFO) };
    PROCESS_INFORMATION pi;
    BOOL success = CreateProcessW(NULL, const_cast<LPWSTR>(wCommand.c_str()), NULL, NULL, FALSE, CREATE_NO_WINDOW, NULL, NULL, &si, &pi);

    // wait for process to finish
    if (success) {
        WaitForSingleObject(pi.hProcess, INFINITE);
        CloseHandle(pi.hProcess);
        CloseHandle(pi.hThread);
    }

    // add the file names to the file_names vector if list is true
    if (list) {
        file_names.push_back(fileName);
    }
    if (install) {
        userPreset = fileName;
    }
}

void extractFile(const std::string& filePath, const std::string& outputDirectory) {
    // filename
    std::string filename = std::filesystem::path(filePath).filename().string();
    // ps command
    std::wstring wFilePath(filePath.begin(), filePath.end());
    std::wstring wOutputDirectory(outputDirectory.begin(), outputDirectory.end());
    std::wstring wCommand = L"C:\\Windows\\System32\\WindowsPowerShell\\v1.0\\powershell.exe -Command \"$ProgressPreference = 'SilentlyContinue'; Expand-Archive -Path '" + wFilePath + L"' -DestinationPath '" + wOutputDirectory + L"'\"";

    // create process parameters
    STARTUPINFOW si = { sizeof(STARTUPINFO) };
    PROCESS_INFORMATION pi;
    BOOL success = CreateProcessW(NULL, const_cast<LPWSTR>(wCommand.c_str()), NULL, NULL, FALSE, CREATE_NO_WINDOW, NULL, NULL, &si, &pi);

    // wait for process to finish
    if (success) {
        WaitForSingleObject(pi.hProcess, INFINITE);
        CloseHandle(pi.hProcess);
        CloseHandle(pi.hThread);
    }

    std::cout << "Extracting file: " << filename << std::endl;
}

void moveFile(const std::string& sourceFilePath, const std::string& destinationFilePath) {
    std::string fileName = fs::path(sourceFilePath).filename().string();
    std::string fullDestinationPath = destinationFilePath + "\\" + fileName;

    if (!fs::exists(fullDestinationPath)) {
        fs::rename(sourceFilePath, fullDestinationPath);
        std::cout << "Moved file: " << fileName << std::endl;
    }
    else {
        std::cout << "Destination file already exists. Skipping move operation." << std::endl;
    }
}

void shortcut() {
    // download RobloxPlayerBeta.exe shortcut
    downloadFile("https://github.com/Extravi/bloxshade-args/releases/latest/download/RobloxPlayerBeta.zip", defaultPath, list = false, install = false);
    extractFile(defaultPath + "\\RobloxPlayerBeta.zip", defaultPath);
    fs::remove(defaultPath + "\\RobloxPlayerBeta.zip");
    std::cout << "Installed shortcut" << std::endl;
}

void verifyFiles(const std::string& path, const std::string& pathToVerify) {
    // verify files
    if (!fs::exists(path) && fs::exists(pathToVerify)) {
        std::cout << "Roblox is installed without eurotrucks2.exe" << std::endl;
        // rename RobloxPlayerBeta.exe to eurotrucks2.exe
        fs::rename(pathToVerify, path);
        // download RobloxPlayerBeta.exe shortcut
        shortcut();
    }
    else if (fs::exists(path) && !fs::exists(pathToVerify)) {
        std::cout << "eurotrucks2.exe is installed without RobloxPlayerBeta.exe" << std::endl;
        // download RobloxPlayerBeta.exe shortcut
        shortcut();
    }
    else if (fs::exists(path) && fs::exists(pathToVerify)) {
        std::cout << "Both RobloxPlayerBeta.exe and eurotrucks2.exe are installed" << std::endl;
        // delete RobloxPlayerBeta.exe and download new shortcut
        fs::remove(pathToVerify);
        // download RobloxPlayerBeta.exe shortcut
        shortcut();
    }
    else {
        std::cout << "Neither RobloxPlayerBeta.exe nor eurotrucks2.exe is installed" << std::endl;
    }
}

int WINAPI wWinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPWSTR lpCmdLine, int nCmdShow) {
    LPWSTR* argv;
    int argc;
    argv = CommandLineToArgvW(GetCommandLineW(), &argc);
    if (argv == NULL) {
        std::cerr << "Failed to parse command line arguments." << std::endl;
        return 1;
    }

    // comment out for output
    output();

    // process arguments
    for (int i = 1; i < argc; ++i) {
        std::wstring arg = argv[i];
        if (arg == L"-shortcut") {
            shortcutarg = true;
        }
        else if (arg == L"-import") {
            import = true;
        }
        else if (arg == L"-fix") {
            fix = true;
        }
        else if (arg == L"-install" && i + 1 < argc) {
            std::cout << "Community presets arg called" << std::endl;
            url = argv[++i];
            std::string url_str(url.begin(), url.end());
            url_str.erase(std::remove(url_str.begin(), url_str.end(), '\"'), url_str.end());
            std::cout << url_str << std::endl;
            downloadFile(url_str, anselPath, list = false, install = true);
            std::string presetsToMove = "\\" + userPreset;
            extractFile(anselPath + presetsToMove, presetsPath);
            fs::remove(anselPath + presetsToMove);
            MessageBoxW(NULL, L"Community presets were installed successfully.", L"Success", MB_OK | MB_ICONINFORMATION);
            return 0;
        }
        else {
            // pass
        }
    }

    // free memory allocated by CommandLineToArgvW
    LocalFree(argv);

    // roblox path
    RegGetValueA(HKEY_CLASSES_ROOT, "roblox-player\\shell\\open\\command", nullptr, RRF_RT_REG_SZ, nullptr, value, &valueSize);

    // convert to C++ string
    std::string robloxPath(value);

    if (robloxPath == "") {
        // show message box
        int result = MessageBoxW(nullptr, L"Roblox installation was not found. Do you want to download it?", L"Warning", MB_OKCANCEL | MB_ICONWARNING);
        if (result == IDOK) {
            ShellExecuteW(nullptr, L"open", L"https://www.roblox.com/download/client", nullptr, nullptr, SW_SHOWNORMAL);
        }
        return 0;
    }
    else {
        std::cout << "Roblox install found" << std::endl;
    }

    // kill any running Roblox process
    WinExec("taskkill /F /IM RobloxPlayerBeta.exe", SW_HIDE);
    WinExec("taskkill /F /IM eurotrucks2.exe", SW_HIDE);

    // extract the path
    size_t start = robloxPath.find('"') + 1;
    size_t end = robloxPath.rfind('"');
    std::string path = robloxPath.substr(start, end - start);
    std::string roPath = robloxPath.substr(start, end - start);

    // bloxstrap
    size_t BloxstrapPos = path.find("Bloxstrap.exe");

    // roblox
    size_t RobloxPos = path.find("RobloxPlayerBeta.exe");

    if (BloxstrapPos != std::string::npos) {
        path.replace(BloxstrapPos, strlen("Bloxstrap.exe"), "State.json");
        bloxstrap = true;
    }

    if (RobloxPos != std::string::npos) {
        path.replace(RobloxPos, strlen("RobloxPlayerBeta.exe"), "eurotrucks2.exe");
    }

    if (bloxstrap) {
        std::cout << "Bloxstrap is true" << std::endl;

        // read json
        std::ifstream file(path);
        if (!file.is_open()) {
            std::cerr << "failed to open file" << std::endl;
            return 1;
        }

        json data;
        try {
            file >> data;
        }
        catch (json::parse_error) {
            std::cerr << "failed to read file" << std::endl;
            return 1;
        }

        std::cout << data["VersionGuid"] << std::endl;

        // set new path
        std::string versionGuid = data["VersionGuid"];
        std::string versionsDir = "Versions\\";
        path.replace(BloxstrapPos, strlen("State.json"), versionsDir + versionGuid);

        bloxstrapPath = path + "\\RobloxPlayerBeta.exe";
        // defaultPath is the path to the Roblox folder
        defaultPath = path;
        path = path + "\\eurotrucks2.exe";
    }
    else {
        std::cout << "Bloxstrap is false" << std::endl;
        // defaultPath is the path to the Roblox folder
        defaultPath = path;
        defaultPath.replace(RobloxPos, strlen("RobloxPlayerBeta.exe"), "");
        defaultPath.erase(defaultPath.find_last_of('\\'));
    }

    // shortcut arg called reinstall shortcut
    if (shortcutarg) {
        std::cout << "shortcutarg arg called" << std::endl;
        // verify path
        if (bloxstrap) {
            // verify files
            verifyFiles(path, bloxstrapPath);
            MessageBox(NULL, L"Shortcuts were set successfully.", L"Information", MB_OK | MB_ICONINFORMATION);
        }
        else {
            // verify files
            verifyFiles(path, roPath);
            MessageBox(NULL, L"Shortcuts were set successfully.", L"Information", MB_OK | MB_ICONINFORMATION);
        }
        return 0;
    }

    // import arg
    if (import) {
        // args called
        std::cout << "Import arg called" << std::endl;

        // file explorer 
        OPENFILENAMEW ofn;
        WCHAR szFile[MAX_PATH] = { 0 };

        ZeroMemory(&ofn, sizeof(ofn));
        ofn.lStructSize = sizeof(ofn);
        ofn.hwndOwner = NULL;
        ofn.lpstrFile = szFile;
        ofn.lpstrFile[0] = L'\0';
        ofn.nMaxFile = sizeof(szFile);
        ofn.lpstrFilter = L"INI Files\0*.ini\0All Files\0*.*\0";
        ofn.nFilterIndex = 1;
        ofn.lpstrFileTitle = NULL;
        ofn.nMaxFileTitle = 0;
        ofn.lpstrInitialDir = NULL;
        ofn.Flags = OFN_PATHMUSTEXIST | OFN_FILEMUSTEXIST | OFN_NOCHANGEDIR;
        ofn.lpstrTitle = L"Import your own Ansel preset";

        if (GetOpenFileNameW(&ofn) == TRUE) {
            std::wstring sourceFileW(szFile);
            std::string sourceFile(sourceFileW.begin(), sourceFileW.end());

            // filename from the full path
            std::string filename = sourceFile.substr(sourceFile.find_last_of("\\") + 1);
            std::string destinationFile = presetsPath + "\\" + filename;

            try {
                fs::copy(sourceFile, destinationFile, fs::copy_options::overwrite_existing);
                MessageBoxW(NULL, L"Imported successfully.", L"Success", MB_OK | MB_ICONINFORMATION);
            }
            catch (const std::filesystem::filesystem_error& ex) {
                std::wstring errorMessage(ex.what(), ex.what() + strlen(ex.what()));
                MessageBoxW(NULL, errorMessage.c_str(), L"Error", MB_OK | MB_ICONERROR);
            }
        }
        return 0;
    }

    // temp folder individual effects not working when they worked in the past fix
    TCHAR tempPath[MAX_PATH];
    DWORD result = GetTempPath(MAX_PATH, tempPath);
    if (result > 0 && result < MAX_PATH) {
        char narrowTempPath[MAX_PATH];
        WideCharToMultiByte(CP_UTF8, 0, tempPath, -1, narrowTempPath, MAX_PATH, NULL, NULL);
        std::cout << "Temporary folder: " << narrowTempPath << std::endl;
        std::string NvCamera = std::string(narrowTempPath) + "NvCamera";
        std::cout << NvCamera << std::endl;
        if (fs::exists(NvCamera)) {
            std::cout << "NvCamera folder true" << std::endl;
            fs::remove_all(NvCamera);
            fs::create_directories(NvCamera);
        }
        else {
            std::cout << "NvCamera folder false" << std::endl;
            fs::create_directories(NvCamera);
        }
    }
    else {
        std::cerr << "Error getting temporary folder path." << std::endl;
    }

    // fix arg called
    if (fix) {
        std::cout << "fix arg called" << std::endl;
        // shaders on wont open menu fix
        try {
            for (const auto& entry : std::filesystem::directory_iterator(presetsPath)) {
                if (entry.is_regular_file()) {
                    std::string filename = entry.path().stem().string();
                    std::string extension = entry.path().extension().string();

                    // add " " to file name
                    if (!filename.empty() && filename.back() == ' ') {
                        filename.pop_back();
                        std::filesystem::rename(entry.path(), entry.path().parent_path() / (filename + extension));
                    }
                    else {
                        filename += " ";
                        std::filesystem::rename(entry.path(), entry.path().parent_path() / (filename + extension));
                    }
                }
            }
            std::cout << "Ansel menu fixed." << std::endl;
            MessageBoxW(NULL, L"Ansel menu fixed.", L"Success", MB_OK | MB_ICONINFORMATION);
        }
        catch (const std::filesystem::filesystem_error& ex) {
            std::cerr << "Filesystem error: " << ex.what() << std::endl;
        }
        catch (...) {
            std::cerr << "An unexpected error occurred." << std::endl;
        }
        return 0;
    }

    // verify path
    if (bloxstrap) {
        // file paths
        std::cout << path << std::endl;
        std::cout << bloxstrapPath << std::endl;
        std::cout << defaultPath << std::endl;
        std::cout << anselPath << std::endl;
        std::cout << presetsPath << std::endl;
        std::cout << shadersPath << std::endl;

        // verify files
        verifyFiles(path, bloxstrapPath);
    }
    else {
        // file paths
        std::cout << path << std::endl;
        std::cout << roPath << std::endl;
        std::cout << defaultPath << std::endl;
        std::cout << anselPath << std::endl;
        std::cout << presetsPath << std::endl;
        std::cout << shadersPath << std::endl;

        // verify files
        verifyFiles(path, roPath);
    }

    // verify nvidia files
    if (fs::exists(anselPath)) {
        std::cout << "Ansel folder true" << std::endl;
        // reinstall folder
        fs::remove_all(anselPath);
        fs::create_directories(presetsPath);
        fs::create_directories(shadersPath);
    }
    else {
        std::cout << "Ansel folder false" << std::endl;
        // create folder
        fs::create_directories(presetsPath);
        fs::create_directories(shadersPath);
    }

    // download files
    for (const std::string& url : urls) {
        downloadFile(url, anselPath, list = true, install = false);
    }

    // extract files
    for (const std::string& file : file_names) {
        extractFile(anselPath + "\\" + file, anselPath);
        fs::remove(anselPath + "\\" + file);
    }

    // move files
    for (const std::string& path : paths) {
        for (const auto& entry : fs::directory_iterator(anselPath + path)) {
            if (fs::is_regular_file(entry)) {
                moveFile(entry.path().string(), anselPath);
            }
        }
    }

    // finish up moving files
    for (const auto& entry : fs::directory_iterator(anselPath + "\\FXShaders-76365e35c48e30170985ca371e67d8daf8eb9a98\\Shaders\\FXShaders")) {
        if (fs::is_regular_file(entry)) {
            moveFile(entry.path().string(), shadersPath);
        }
    }

    // Ansel presets
    for (const auto& entry : fs::directory_iterator(anselPath + "\\ansel-presets")) {
        if (fs::is_regular_file(entry)) {
            moveFile(entry.path().string(), presetsPath);
        }
    }

    // remove unused folders
    std::cout << "Removing unused folders" << std::endl;
    for (std::string path : paths) {
        path.replace(path.find("\\", path.find("\\") + 1), path.length(), "");
        path = anselPath + path;
        std::cout << "Removing folder: " + path << std::endl;
        fs::remove_all(path);
    }

    // remove files outside of the loop
    fs::remove_all(anselPath + "\\ansel-presets");
    fs::remove(anselPath + "\\LICENSE");

    // cleanup problematic shaders
    fs::remove(anselPath + "\\DOF.fx");
    fs::remove(anselPath + "\\FakeMotionBlur.fx");
    fs::remove(anselPath + "\\MotionBlur.fx");
    fs::remove(anselPath + "\\NiceGuy_Lamps.fx");

    // exit output
    std::cout << "0" << std::endl;

    // debug to read output
    //std::cin.get();
    return 0;
}
