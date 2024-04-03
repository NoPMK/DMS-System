#ifndef USERINTERFACESERVICE_H
#define USERINTERFACESERVICE_H

#include "Precompiled.h"
#include "IUserInterfaceService.h"
#include "FileOperationService.h"
#include "FolderOperationService.h"
#include <unordered_map>
#include <functional>
#include <string>

class UserInterfaceService : public IUserInterfaceService {

    std::unordered_map<std::string, std::function<void()>> commandMap;
    void InitializeCommandMap();

public:
    UserInterfaceService(IFileOperationService& fileOpsService, IFolderOperationService& folderOpsService);
    void Run() override;

private:
    IFileOperationService& fileOpsService;
    IFolderOperationService& folderOpsService;

    void ProcessCommand(const std::string& command);

    // File Wrappers
    void CreateFile();
    void ReadFile();
    void UpdateFile();
    void DeleteFile();
    void MoveFile();

    //Folder Wrappers
    void CreateFolder();
    void DeleteFolder();
    void RenameFolder();
    void MoveFolder();
    void OpenFolder();
};

#endif
