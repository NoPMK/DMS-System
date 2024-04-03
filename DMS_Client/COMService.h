#pragma once
#ifndef COMSERVICE_H
#define COMSERVICE_H

#include "IFileOperationService.h"
#include "IFolderOperationService.h"
#include "IUserInterfaceService.h"
#include <memory>

class ComService {
public:
    ComService();
    ~ComService();

    bool IsInitialized() const;
    HRESULT Result() const;
    void RunUserInterface();
    void InitializeServices();

private:
    HRESULT hr;
    std::unique_ptr<IFileOperationService> fileOpsService;
    std::unique_ptr<IFolderOperationService> folderOpsService;
    std::unique_ptr<IUserInterfaceService> uiService;
};

#endif 
