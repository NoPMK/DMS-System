#pragma once
#include <string>

class IFileOperationService {
public:
    virtual void CreateFile(const std::wstring& filePath) = 0;
    virtual std::wstring ReadFile(const std::wstring& filePath) = 0;
    virtual void UpdateFile(const std::wstring& filePath, const std::wstring& newContent) = 0;
    virtual void DeleteFile(const std::wstring& filePath) = 0;
    virtual void MoveFile(const std::wstring& originalFilePath, const std::wstring& newFilePath) = 0;
    virtual ~IFileOperationService() {}
};