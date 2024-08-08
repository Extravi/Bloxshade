// Description: Bloxshade installer source code.
// Author: Dante (dante@extravi.dev)
// Date: 2024-06-14

#include <iostream>
#include <fstream>
#include <string>
#include <locale>
#include <codecvt>
#include <cstring>
#include <Windows.h>
#include <shellapi.h>

#include "json.hpp"

using json = nlohmann::json;

// namespace for fs
namespace fs = std::filesystem;

// curl
#define CURL_STATICLIB
#include "curl/curl.h"

// miniz
#include "miniz.h"

// fopen
#pragma warning(disable : 4996)

// variables 
wchar_t value[MAX_PATH];
DWORD valueSize = sizeof(value);
bool bloxstrap = false;
bool list = false;
bool skip = false;
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
bool open = false;
bool dark = false;
bool nv = false;

// nvidia paths
const std::string anselPath = "C:\\Program Files\\NVIDIA Corporation\\Ansel";
const std::string presetsPath = "C:\\Program Files\\NVIDIA Corporation\\Ansel\\Custom";
const std::string shadersPath = "C:\\Program Files\\NVIDIA Corporation\\Ansel\\FXShaders";

// for bool open
const std::wstring wPresetsPath = L"C:\\Program Files\\NVIDIA Corporation\\Ansel\\Custom";

// install file
const std::string installtxt = "C:\\Program Files\\Bloxshade\\install.txt";

// nv app patch
const std::string nvapp = "C:\\Program Files\\Bloxshade\\nv";

// redirect std::cout to the install file
void output() {
    static std::ofstream installFile(installtxt, std::ios::app);
    static std::streambuf* coutBuffer = std::cout.rdbuf();
    std::cout.rdbuf(installFile.rdbuf());
}

// urls
std::vector<std::string> urls = {
    "https://github.com/CeeJayDK/SweetFX/archive/a792aee788c6203385a858ebdea82a77f81c67f0.zip",
    "https://github.com/Extravi/prod80-ReShade-Repository/archive/75060ee709b6aa9eff9d0f8fbaaa18c9c3ab8e9f.zip",
    "https://github.com/Extravi/extravi.github.io/raw/main/update/dependencies.zip",
    "https://github.com/crosire/reshade-shaders/archive/fb9dcb99034759cd437610b7657307d52f8086ff.zip",
    "https://github.com/martymcmodding/qUINT/archive/98fed77b26669202027f575a6d8f590426c21ebd.zip",
    "https://github.com/crosire/reshade-shaders/archive/1258f18337a1f186740a6c4cb747c1aa6f0d79a9.zip",
    "https://github.com/Not-Smelly-Garbage/OldReshadeShaders/archive/86772ee94877f82a97c49af05b8bca84d9065de7.zip",
    "https://github.com/Fubaxiusz/fubax-shaders/archive/c83190dd11b26c75a51a1b452106c8d170771e28.zip",
    "https://github.com/Otakumouse/stormshade/archive/6dad6589fe505e998b01295dc6c647b031386e74.zip",
    "https://github.com/Extravi/NiceGuy-Shaders/archive/4e9c00f0fb00b74fbc2bd0e63d290c140e23d493.zip",
    "https://github.com/rj200/Glamarye_Fast_Effects_for_ReShade/archive/9dd9b826fa2cbea818ef1bc487e5f2e7f427c750.zip",
    "https://github.com/AlucardDH/dh-reshade-shaders/archive/f3ca553f9012caced93f273890d20ea427865fd5.zip",
    "https://github.com/BlueSkyDefender/AstrayFX/archive/910e3213a846b34dd65d94e84b61b61fca69dd6d.zip",
    "https://github.com/luluco250/FXShaders/archive/76365e35c48e30170985ca371e67d8daf8eb9a98.zip",
    "https://github.com/crosire/reshade-shaders/archive/6b452c4a101ccb228c4986560a51c571473c517b.zip",
    "https://github.com/Extravi/ansel-shaders/archive/c286b39f3dc680c6c98f154f512a5109e213aa67.zip",
    "https://github.com/bituq/ZealShaders/archive/e4753908efda49d5423f4e0395161608c9207e2e.zip",
    "https://github.com/Fubaxiusz/fubax-shaders-dev/archive/023c080ac489fbe09b1c8e2975eaee340d7a0745.zip"
};

//file paths
std::vector<std::string> paths = {
    "\\reshade-shaders-6b452c4a101ccb228c4986560a51c571473c517b\\ShadersAndTextures", // ReShade Nvidia
    "\\SweetFX-a792aee788c6203385a858ebdea82a77f81c67f0\\Shaders", // SweetFX
    "\\SweetFX-a792aee788c6203385a858ebdea82a77f81c67f0\\Textures",
    "\\prod80-ReShade-Repository-75060ee709b6aa9eff9d0f8fbaaa18c9c3ab8e9f\\Shaders", // prod80
    "\\prod80-ReShade-Repository-75060ee709b6aa9eff9d0f8fbaaa18c9c3ab8e9f\\Textures",
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
    "\\NiceGuy-Shaders-4e9c00f0fb00b74fbc2bd0e63d290c140e23d493\\Shaders", // NiceGuy
    "\\NiceGuy-Shaders-4e9c00f0fb00b74fbc2bd0e63d290c140e23d493\\Textures",
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
size_t writedata(char* ptr, size_t size, size_t nmemb, void* stream) {
    return fwrite(ptr, size, nmemb, (FILE*)stream);
}

void downloadFile(const std::string& url, const std::string& outputdirectory, bool list, bool install) {
    // file path and name
    std::string filename = url.substr(url.find_last_of('/') + 1);
    std::string outputpath = outputdirectory + "\\" + filename;

    // open a new curl handle
    CURL* curl = curl_easy_init();

    if (curl) {
        // set download URL
        curl_easy_setopt(curl, CURLOPT_URL, url.c_str());

        // follow redirects
        curl_easy_setopt(curl, CURLOPT_FOLLOWLOCATION, 1L);

        // open output file for writing
        FILE* outputfile = fopen(outputpath.c_str(), "wb");

        if (outputfile) {
            // set write callback function
            curl_easy_setopt(curl, CURLOPT_WRITEFUNCTION, writedata);

            // set userdata for write callback
            curl_easy_setopt(curl, CURLOPT_WRITEDATA, outputfile);

            // perform the download operation
            CURLcode res = curl_easy_perform(curl);

            // close output file
            fclose(outputfile);

            if (res != CURLE_OK) {
                // handle curl error
                std::cout << "curl_easy_perform failed: " << curl_easy_strerror(res) << std::endl;
            }
            else {
                std::cout << "Downloading: " << filename << std::endl;
            }
        }
        else {
            std::cout << "error opening output file: " << outputpath << std::endl;
        }

        // cleanup curl handle
        curl_easy_cleanup(curl);
    }
    else {
        std::cout << "failed to initialize curl" << std::endl;
    }

    // add the file names to the file_names vector if list is true
    if (list) {
        file_names.push_back(filename);
    }
    if (install) {
        userPreset = filename;
    }
}

void extractFile(const std::string& filePath, const std::string& outputDirectory) {
    // filename
    std::string filename = std::filesystem::path(filePath).filename().string();

    // read the archive
    mz_zip_archive zip_archive;
    memset(&zip_archive, 0, sizeof(zip_archive));
    if (!mz_zip_reader_init_file(&zip_archive, filePath.c_str(), 0)) {
        std::cout << "failed to open zip file: " << filePath << std::endl;
        return;
    }

    // iterate through each file in the archive
    int num_files = mz_zip_reader_get_num_files(&zip_archive);
    for (int i = 0; i < num_files; i++) {
        mz_zip_archive_file_stat file_stat;
        if (!mz_zip_reader_file_stat(&zip_archive, i, &file_stat)) {
            std::cout << "failed to get file stat for index: " << i << std::endl;
            continue;
        }

        // output path
        std::string entry_name = file_stat.m_filename;
        std::string output_path = outputDirectory + "\\" + entry_name;

        // create directory for the each entry in the archive
        if (entry_name.back() == '/') {
            if (!std::filesystem::create_directories(output_path)) {
                // idc uwu
            }
            continue;
        }

        // extract file
        std::filesystem::create_directories(std::filesystem::path(output_path).parent_path());
        if (!mz_zip_reader_extract_to_file(&zip_archive, i, output_path.c_str(), 0)) {
            std::cout << "failed to extract file: " << entry_name << std::endl;
        }
    }

    // close the zip file
    mz_zip_reader_end(&zip_archive);
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
        // show message box
        int result = MessageBoxW(nullptr, L"Roblox installation was not found. Do you want to download it?", L"Warning", MB_OKCANCEL | MB_ICONWARNING);
        if (result == IDOK) {
            ShellExecuteW(nullptr, L"open", L"https://www.roblox.com/download/client", nullptr, nullptr, SW_SHOWNORMAL);
        }
        exit(0);
    }
}

int WINAPI wWinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPWSTR lpCmdLine, int nCmdShow) {
    std::locale::global(std::locale("en_US.UTF-8"));
    std::cout.imbue(std::locale());

    LPWSTR* argv;
    int argc;
    argv = CommandLineToArgvW(GetCommandLineW(), &argc);
    if (argv == NULL) {
        std::cout << "Failed to parse command line arguments." << std::endl;
        return 1;
    }

    // comment out for output
    output();
    // installer version
    std::cout << "* Version: 2.8.11\n";
    std::cout << "* Bloxshade Installer (developed by Extravi, https://extravi.dev/)\n";
    std::cout << "* Copyright © 2024 Extravi\n";
    std::cout << "* Source Code: https://github.com/Extravi/Bloxshade\n";

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
        else if (arg == L"-open") {
            open = true;
        }
        else if (arg == L"-dark") {
            dark = true;
        }
        else if (arg == L"-nv") {
            nv = true;
        }
        else {
            // pass
        }
    }

    // free memory allocated by CommandLineToArgvW
    LocalFree(argv);

    // roblox path
    RegGetValueW(HKEY_CURRENT_USER, L"Software\\Classes\\roblox-player\\shell\\open\\command", nullptr, RRF_RT_REG_SZ, nullptr, value, &valueSize);

    // convert string
    std::wstring_convert<std::codecvt_utf8<wchar_t>, wchar_t> converter;
    std::wstring wstrValue(value);
    std::string robloxPath = converter.to_bytes(wstrValue);

    // check if path is empty
    if (robloxPath == "") {
        // show message box
        int result = MessageBoxW(nullptr, L"Roblox installation was not found. Do you want to download it?", L"Warning", MB_OKCANCEL | MB_ICONWARNING);
        if (result == IDOK) {
            ShellExecuteW(nullptr, L"open", L"https://www.roblox.com/download/client", nullptr, nullptr, SW_SHOWNORMAL);
        }
        return 0;
    }

    // print the reg key
    std::cout << robloxPath << std::endl;

    // extract the path
    size_t start = robloxPath.find('"') + 1;
    size_t end = robloxPath.rfind('"');
    std::string path = robloxPath.substr(start, end - start);
    std::string roPath = robloxPath.substr(start, end - start);

    // check the path
    std::cout << "Path to check: " << path << std::endl; // show the path
    if (path.find("C:\\Program Files") == 0 || path.find("C:\\Program Files (x86)") == 0) {
        std::cout << "Program files is true" << std::endl;
        MessageBox(NULL, L"It seems like Roblox is installed system-wide in the Program Files directory. Please install Roblox in a location other than the Program Files directory.", L"Information", MB_OK | MB_ICONWARNING);
        return 0;
    }
    else {
        std::cout << "Program files is false" << std::endl;
    }

    // check if path is under the users directory
    if (path.find("C:\\Users") == 0) {
        std::cout << "Users path is true" << std::endl;
    }
    else {
        std::cout << "Users path is false" << std::endl;
        std::cout << path << std::endl;
    }

    // Roblox seems to be installled from reg key
    std::cout << "Roblox install found" << std::endl;

    // kill any running Roblox process
    WinExec("taskkill /F /IM RobloxPlayerBeta.exe", SW_HIDE);
    WinExec("taskkill /F /IM eurotrucks2.exe", SW_HIDE);

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
            std::cout << "failed to open file" << std::endl;
            return 1;
        }

        json data;
        try {
            file >> data;
        }
        catch (json::parse_error) {
            std::cout << "failed to read file" << std::endl;
            return 1;
        }

        std::cout << data["VersionGuid"] << std::endl;

        if (data["VersionGuid"].is_null()) {
            std::cout << "trying something else" << std::endl;
            std::cout << data["PlayerVersionGuid"] << std::endl;
        }

        // set new path
        std::string versionGuid;
        if (data["VersionGuid"].is_null()) {
            std::cout << "setting new versionGuid" << std::endl;
            versionGuid = data["PlayerVersionGuid"];
        }
        else {
            versionGuid = data["VersionGuid"];
        }
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

    if (open) {
        // verify if custom folder exist
        if (fs::exists(presetsPath)) {
            std::cout << "Custom folder true" << std::endl;
            ShellExecuteW(nullptr, L"open", wPresetsPath.c_str(), nullptr, nullptr, SW_SHOWNORMAL);
            return 0;
        }
        else {
            std::cout << "Custom folder false" << std::endl;
            MessageBox(NULL, L"It seems like Nvidia Ansel is not installed on your computer. Please install the Ansel folder first using the Bloxshade installer.", L"Information", MB_OK | MB_ICONWARNING);
            return 0;
        }
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
        std::cout << "Error getting temporary folder path." << std::endl;
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
            std::cout << "Filesystem error: " << ex.what() << std::endl;
        }
        catch (...) {
            std::cout << "An unexpected error occurred." << std::endl;
        }
        return 0;
    }

    // nv arg to install the nvidia app
    if (nv) {
        // nv arg called
        std::cout << "nv arg called" << std::endl;
        // verify bloxshade nv folder
        if (fs::exists(nvapp)) {
            std::cout << "nv folder true" << std::endl;
            // reinstall folder
            fs::remove_all(nvapp);
            fs::create_directories(nvapp);
        }
        else {
            std::cout << "nv folder false" << std::endl;
            // create folder
            fs::create_directories(nvapp);
        }
        downloadFile("https://us.download.nvidia.com/nvapp/client/10.0.1.256/NVIDIA_app_beta_v10.0.1.256.exe", nvapp, list = false, install = false);
        downloadFile("https://github.com/Extravi/nv-profile/raw/main/7za.exe", nvapp, list = false, install = false);
        downloadFile("https://raw.githubusercontent.com/Extravi/nv-profile/main/component_profiles.json", nvapp, list = false, install = false);
        // extract the installer with 7zip
        std::wstring command = L"cmd.exe /c \"cd \"C:\\Program Files\\Bloxshade\\nv\" && \"C:\\Program Files\\Bloxshade\\nv\\7za.exe\" x \"C:\\Program Files\\Bloxshade\\nv\\NVIDIA_app_beta_v10.0.1.256.exe\"\"";
        // create process parameters
        auto createAndCloseProcess = [](const std::wstring& command) {
        STARTUPINFOW si = { sizeof(STARTUPINFO) };
        PROCESS_INFORMATION pi;
        if (CreateProcessW(NULL, const_cast<LPWSTR>(command.c_str()), NULL, NULL, FALSE, CREATE_NO_WINDOW, NULL, NULL, &si, &pi)) {
            WaitForSingleObject(pi.hProcess, INFINITE);
            CloseHandle(pi.hProcess);
            CloseHandle(pi.hThread);
        }
        };
        // wait for process to finish
        createAndCloseProcess(command);
        // print update component path
        std::cout << nvapp + "\\NvApp\\CEF\\UpdateFrameworkPlugins\\component_profiles.json" << std::endl;
        // check if update component exist
        if (fs::exists(nvapp + "\\NvApp\\CEF\\UpdateFrameworkPlugins\\component_profiles.json")) {
            std::cout << "update component true" << std::endl;
            // remove the file
            fs::remove(nvapp + "\\NvApp\\CEF\\UpdateFrameworkPlugins\\component_profiles.json");
            std::cout << "setting a new update component" << std::endl;
            std::string nvappupdatecomponent = "C:\\Program Files\\Bloxshade\\nv\\NvApp\\CEF\\UpdateFrameworkPlugins";
            // disable updates
            moveFile(nvapp + "\\component_profiles.json", nvappupdatecomponent);
            std::cout << "nvapp patched and updates disabled" << std::endl;
        }
        std::string nvappPath = "C:\\Program Files\\Bloxshade\\nv\\setup.exe";
        // start installer
        std::cout << "starting nvapp installer with updates disabled" << std::endl;
        WinExec(nvappPath.c_str(), SW_HIDE);
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

    if (dark == true) {
        downloadFile("https://github.com/Extravi/extravi.github.io/raw/main/update/ansel-presets-dark.zip", anselPath, list = true, install = false);
        extractFile(anselPath + "\\" + "ansel-presets-dark.zip", anselPath);
        fs::remove(anselPath + "\\" + "ansel-presets-dark.zip");
    }
    else {
        downloadFile("https://github.com/Extravi/extravi.github.io/raw/main/update/ansel-presets.zip", anselPath, list = true, install = false);
        extractFile(anselPath + "\\" + "ansel-presets.zip", anselPath);
        fs::remove(anselPath + "\\" + "ansel-presets.zip");
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
