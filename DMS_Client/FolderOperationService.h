#ifndef FOLDEROPERATIONSERVICE_H
#define FOLDEROPERATIONSERVICE_H

#include "Precompiled.h"
#include "IFolderOperationService.h" 
#include <string>
#include <stdexcept>
#include "DMS_Server_h.h"

class FolderOperationService : public IFolderOperationService
{
public:
	FolderOperationService();
	~FolderOperationService();

	void CreateFolder(const std::wstring& filepath);
	void DeleteFolder(const std::wstring& filepath);
	void RenameFolder(const std::wstring& originalFilePath, const std::wstring& newFolderName);
	void MoveFolder(const std::wstring& originalFilePath, const std::wstring& newFolderPath);
	void OpenFolder(const std::wstring& FilePath);

private:
	void InitializeFolderOperationInterface();
	IFolderOperations* pFolderOps;
};

#endif