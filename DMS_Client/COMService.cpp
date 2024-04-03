#include "Precompiled.h"
#include "FileOperationService.h"
#include "UserInterfaceService.h"
#include "COMService.h"
#include <iostream>

ComService::ComService() : hr(CoInitialize(nullptr)) {
	if (!SUCCEEDED(hr)) {
		std::cerr << "Failed to initialize COM. HRESULT: " << hr << std::endl;
	}
	std::cout << "COM service is initialized" << std::endl;
}

//RECOMPILE THIS AND DLL TOO

ComService::~ComService() {
	if (SUCCEEDED(hr)) {
		CoUninitialize();
	}
}

void ComService::InitializeServices() {
	fileOpsService = std::make_unique<FileOperationService>();
	std::cout << "FileOps service is initialized" << std::endl;
	folderOpsService = std::make_unique<FolderOperationService>();
	std::cout << "FolderOps service is initialized" << std::endl;
	uiService = std::make_unique<UserInterfaceService>(*fileOpsService.get(), *folderOpsService.get());
	std::cout << "UI service is initialized" << std::endl;
}

void ComService::RunUserInterface() {
	if (uiService) {
		uiService->Run();
	}
	else {
		std::cerr << "User interface service is not initialized." << std::endl;
	}
}

bool ComService::IsInitialized() const {
	return SUCCEEDED(hr) && fileOpsService && folderOpsService && uiService;
}

HRESULT ComService::Result() const {
	return hr;
}