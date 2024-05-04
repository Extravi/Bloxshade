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
    if (!IsUserAnAdmin()) {
        MessageBox(NULL, L"Oops! You need to run this program as admin! >.< It's okay! If you don't have perms, ask your parent or guardian on how to run it as so!", L"Error", MB_ICONERROR | MB_OK);
        return 0;
    }

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