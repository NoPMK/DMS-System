#pragma once
#include <string>

class IFolderOperationService {
public:
	virtual void CreateFolder(const std::wstring& filePath) = 0;
	virtual void DeleteFolder(const std::wstring& filePath) = 0;
	virtual void RenameFolder(const std::wstring& originalFilePath, const std::wstring& newFolderName) = 0;
	virtual void MoveFolder(const std::wstring& originalFilePath, const std::wstring& newFolderPath) = 0;
	virtual void OpenFolder(const std::wstring& FilePath) = 0;
	virtual ~IFolderOperationService() {}
};