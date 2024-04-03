#ifndef FILEOPERATIONSERVICE_H
#define FILEOPERATIONSERVICE_H

#include "Precompiled.h"
#include "IFileOperationService.h" 
#include <string>
#include <stdexcept>
#include "DMS_Server_h.h"


class FileOperationService : public IFileOperationService {
public:
	FileOperationService();
	~FileOperationService();

	void CreateFile(const std::wstring& filePath);
	std::wstring ReadFile(const std::wstring& filePath);
	void UpdateFile(const std::wstring& filePath, const std::wstring& newContent);
	void DeleteFile(const std::wstring& filePath);
	void MoveFile(const std::wstring& orginialFilePath, const std::wstring& newFilePath);

private:
	void InitializeFileOperationsInterface();
	IFileOperations* pFileOps;
};

#endif