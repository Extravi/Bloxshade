// Description: Bloxshade installer source code.
// Author: Dante (dante@extravi.dev)
// Date: 2024-06-04

#include <iostream>
#include <fstream>
#include <string>
#include <cstring>
#include <Windows.h>
#include <shellapi.h>
#include <filesystem>
#include <shlobj_core.h>

// resource file
#include "../resource.h"

// namespace for fs
namespace fs = std::filesystem;

// bloxshade path
const std::string bloxshadePath = "C:\\Program Files\\Bloxshade";
const std::string installerPath = "C:\\Program Files\\Bloxshade\\setup.exe";

bool ExtractEmbeddedExe(HRSRC hResInfo, HGLOBAL hResData, DWORD resourceSize,
    const char* outputFilename) {
    if (!hResInfo || !hResData || !resourceSize) {
        // invalid resource
        return false;
    }

    const BYTE* pData = (const BYTE*)LockResource(hResData);
    if (!pData) {
        // could not lock resource data
        return false;
    }

    std::ofstream outputFile(outputFilename, std::ios::binary);
    if (!outputFile.is_open()) {
        // could not open output file
        return false;
    }

    outputFile.write(reinterpret_cast<const char*>(pData), resourceSize);
    outputFile.close();

    FreeResource(hResData);
    return true;
}

int WINAPI wWinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPWSTR lpCmdLine, int nCmdShow) {
    std::locale::global(std::locale("en_US.UTF-8"));
    std::cout.imbue(std::locale());

    if (!IsUserAnAdmin()) {
        MessageBox(NULL, L"Oops! You need to run this program as admin! >.< It's okay! If you don't have perms, ask your parent or guardian on how to run it as so!", L"Error", MB_ICONERROR | MB_OK);
        return 0;
    }

    // edge webview2
    const TCHAR* hklmPath = TEXT("SOFTWARE\\WOW6432Node\\Microsoft\\EdgeUpdate\\Clients\\{F3017226-FE2A-4295-8BDF-00C3A9A7E4C5}");
    const TCHAR* hkcuPath = TEXT("Software\\Microsoft\\EdgeUpdate\\Clients\\{F3017226-FE2A-4295-8BDF-00C3A9A7E4C5}");

    HKEY hklmKey = nullptr;
    HKEY hkcuKey = nullptr;
    LONG lRes1, lRes2;

    // system wide key
    lRes1 = RegOpenKeyEx(HKEY_LOCAL_MACHINE, hklmPath, 0, KEY_READ, &hklmKey);
    // current user key
    lRes2 = RegOpenKeyEx(HKEY_CURRENT_USER, hkcuPath, 0, KEY_READ, &hkcuKey);

    if (lRes1 == ERROR_SUCCESS || lRes2 == ERROR_SUCCESS) {
        // at least one of the keys exists
        std::cout << "Registry key exists." << std::endl;

        // close the opened keys if they were opened 
        if (hklmKey != nullptr) {
            RegCloseKey(hklmKey);
        }
        if (hkcuKey != nullptr) {
            RegCloseKey(hkcuKey);
        }
    }
    else {
        // show message box if edge webview2 runtime was not found
        int result = MessageBoxW(nullptr, L"You seem to be missing the Edge WebView2 runtime. Do you want to install it? The installer requires Edge WebView2 for the user interface to work correctly. Please run the Edge WebView2 runtime setup as an administrator to ensure it installs correctly.", L"Warning", MB_OKCANCEL | MB_ICONWARNING);
        if (result == IDOK) {
            ShellExecuteW(nullptr, L"open", L"https://go.microsoft.com/fwlink/p/?LinkId=2124703", nullptr, nullptr, SW_SHOWNORMAL);
        }
        return 0;
    }

    // kill any running process that may have the folder open
    std::wstring killCommandInstaller = L"cmd.exe /c taskkill /F /IM installer.exe";
    std::wstring killCommandSetup = L"cmd.exe /c taskkill /F /IM setup.exe";

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
    createAndCloseProcess(killCommandInstaller);
    createAndCloseProcess(killCommandSetup);

    if (fs::exists(bloxshadePath)) {
        std::cout << "Bloxshade folder true" << std::endl;
        fs::remove_all(bloxshadePath);
        fs::create_directories(bloxshadePath);
    }
    else {
        std::cout << "Bloxshade folder false" << std::endl;
        fs::create_directories(bloxshadePath);
    }

    HRSRC hResInfo;
    HGLOBAL hResData;
    DWORD resourceSize;

    // extract setup.exe
    hResInfo = FindResource(NULL, MAKEINTRESOURCE(SETUP_BINARY), L"BINARY");
    if (hResInfo) {
        hResData = LoadResource(NULL, hResInfo);
        resourceSize = SizeofResource(NULL, hResInfo);
        if (ExtractEmbeddedExe(hResInfo, hResData, resourceSize, (bloxshadePath + "\\setup.exe").c_str())) {
            std::cout << "setup.exe extracted successfully." << std::endl;
        }
    }
    else {
        std::cerr << "Warning: setup.exe resource not found." << std::endl;
    }

    // extract installer.exe
    hResInfo = FindResource(NULL, MAKEINTRESOURCE(INSTALLER_BINARY), L"BINARY");
    if (hResInfo) {
        hResData = LoadResource(NULL, hResInfo);
        resourceSize = SizeofResource(NULL, hResInfo);
        if (ExtractEmbeddedExe(hResInfo, hResData, resourceSize, (bloxshadePath + "\\installer.exe").c_str())) {
            std::cout << "installer.exe extracted successfully." << std::endl;
        }
    }
    else {
        std::cerr << "Warning: installer.exe resource not found." << std::endl;
    }

    // start installer
    WinExec(installerPath.c_str(), SW_HIDE);

    // debug wait for input
    //std::cin.get();
    return 0;
}
