#include "Precompiled.h"
#include "UserInterfaceService.h"
#include <iostream>
#include <stdexcept>

UserInterfaceService::UserInterfaceService(IFileOperationService& fileOpsService, IFolderOperationService& folderOpsService)
    : fileOpsService(fileOpsService), folderOpsService(folderOpsService) {
    InitializeCommandMap();
}

void UserInterfaceService::InitializeCommandMap() {
    commandMap = {
        {"create file", [this]() { CreateFile(); }},
        {"read file",   [this]() { ReadFile(); }},
        {"update file", [this]() { UpdateFile(); }},
        {"delete file", [this]() { DeleteFile(); }},
        {"move file",   [this]() { MoveFile(); }},
        {"create folder", [this]() { CreateFolder(); }},
        {"delete folder", [this]() { DeleteFolder(); }},
        {"rename folder", [this]() { RenameFolder(); }},
        {"move folder",   [this]() { MoveFolder(); }},
        {"open folder",   [this]() { OpenFolder(); }}
    };
}

void UserInterfaceService::Run() {
    std::string command;
    while (true) {
        std::cout << "Enter command\n| create file\n| read file\n| update file\n| delete file\n| move file\n| create folder\n| delete folder\n| rename folder\n| move folder\n| open folder\n| exit\n ";
        std::getline(std::cin, command);

        if (command == "exit") {
            break;
        }

        ProcessCommand(command);
    }
}

void UserInterfaceService::ProcessCommand(const std::string& command) {
    auto it = commandMap.find(command);
    if (it != commandMap.end()) {
        it->second();
    }
    else {
        std::cout << "Invalid command. Please try again." << std::endl;
    }
}

//FILES

void UserInterfaceService::CreateFile() {
    std::wstring filePath;
    std::cout << "Enter file path to create: ";
    std::getline(std::wcin, filePath);

    try {
        fileOpsService.CreateFile(filePath);
        std::cout << "File created successfully." << std::endl;
    }
    catch (const std::exception& e) {
        std::cerr << "Error: " << e.what() << std::endl;
    }
}

void UserInterfaceService::ReadFile() {
    std::wstring filePath;
    std::cout << "Enter file path to read: ";
    std::getline(std::wcin, filePath);

    try {
        std::wstring content = fileOpsService.ReadFile(filePath);
        std::wcout << L"File content: " << content << std::endl;
    }
    catch (const std::exception& e) {
        std::cerr << "Error: " << e.what() << std::endl;
    }
}

void UserInterfaceService::UpdateFile() {
    std::wstring filePath, newContent;
    std::cout << "Enter file path to update: ";
    std::getline(std::wcin, filePath);
    std::cout << "Enter new content: ";
    std::getline(std::wcin, newContent);

    try {
        fileOpsService.UpdateFile(filePath, newContent);
        std::cout << "File updated successfully." << std::endl;
    }
    catch (const std::exception& e) {
        std::cerr << "Error: " << e.what() << std::endl;
    }
}

void UserInterfaceService::DeleteFile() {
    std::wstring filePath;
    std::cout << "Enter file path to delete: ";
    std::getline(std::wcin, filePath);

    try {
        fileOpsService.DeleteFile(filePath);
        std::cout << "File deleted successfully." << std::endl;
    }
    catch (const std::exception& e) {
        std::cerr << "Error: " << e.what() << std::endl;
    }
}

void UserInterfaceService::MoveFile() {
    std::wstring filePath, newPath;
    std::cout << "Enter file path to move: ";
    std::getline(std::wcin, filePath);
    std::cout << "Enter new location: ";
    std::getline(std::wcin, newPath);

    try {
        fileOpsService.MoveFile(filePath, newPath);
        std::cout << "File successfully moved." << std::endl;
    }
    catch (const std::exception& e) {
        std::cerr << "Error: " << e.what() << std::endl;
    }
}

//FOLDERS

void UserInterfaceService::CreateFolder() {
    std::wstring filePath;
    std::cout << "Enter folder path to create: ";
    std::getline(std::wcin, filePath);

    try {
        folderOpsService.CreateFolder(filePath);
        std::cout << "Folder created successfully." << std::endl;
    }
    catch (const std::exception& e) {
        std::cerr << "Error: " << e.what() << std::endl;
    }
}

void UserInterfaceService::DeleteFolder() {
    std::wstring filePath;
    std::cout << "Enter folder path to delete: ";
    std::getline(std::wcin, filePath);

    try {
        folderOpsService.DeleteFolder(filePath);
        std::cout << "Folder deleted successfully." << std::endl;
    }
    catch (const std::exception& e) {
        std::cerr << "Error: " << e.what() << std::endl;
    }
}

void UserInterfaceService::RenameFolder() {
    std::wstring filePath, newName;
    std::cout << "Enter folder path to rename: ";
    std::getline(std::wcin, filePath);
    std::cout << "Enter new name: ";
    std::getline(std::wcin, newName);

    try {
        folderOpsService.RenameFolder(filePath, newName);
        std::cout << "Folder successfully renamed." << std::endl;
    }
    catch (const std::exception& e) {
        std::cerr << "Error: " << e.what() << std::endl;
    }
}

void UserInterfaceService::MoveFolder() {
    std::wstring filePath, newPath;
    std::cout << "Enter folder path to move: ";
    std::getline(std::wcin, filePath);
    std::cout << "Enter new location: ";
    std::getline(std::wcin, newPath);

    try {
        folderOpsService.MoveFolder(filePath, newPath);
        std::cout << "Folder successfully moved." << std::endl;
    }
    catch (const std::exception& e) {
        std::cerr << "Error: " << e.what() << std::endl;
    }
}

void UserInterfaceService::OpenFolder() {
    std::wstring filePath;
    std::cout << "Enter folder path to open: ";
    std::getline(std::wcin, filePath);

    try {
        folderOpsService.OpenFolder(filePath);
        std::cout << "Folder opened." << std::endl;
    }
    catch (const std::exception& e) {
        std::cerr << "Error: " << e.what() << std::endl;
    }
}