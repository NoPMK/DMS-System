#pragma once

#include "DMS_Server_h.h"
#include <Windows.h>
#include "OperationsBase.h"
#include <unknwn.h>
#include <string>

interface IOperationsEvents;

class FileOperations : public IFileOperations, public OperationsBase {
public:
    FileOperations();
    virtual ~FileOperations();

    // IUnknown methods
    HRESULT __stdcall QueryInterface(REFIID riid, void** ppvObject) override;
    ULONG __stdcall AddRef() override;
    ULONG __stdcall Release() override;

    // IFileOperations methods
    HRESULT __stdcall CreateFile(const BSTR filePath) override;
    HRESULT __stdcall DeleteFile(const BSTR filePath) override;
    HRESULT __stdcall ReadFile(const BSTR filePath) override;
    HRESULT __stdcall RenameFile(const BSTR filePath, BSTR newFileName) override;
    HRESULT __stdcall MoveFile(const BSTR originalFilePath, BSTR newFilePath) override;
    HRESULT __stdcall CopyFile(const BSTR originalFilePath, BSTR newFilePath) override;


    HRESULT __stdcall SubscribeToEvent(IOperationsEvents* eventHandler) override {
        return OperationsBase::SubscribeToEvent(eventHandler);
    }
    HRESULT __stdcall UnsubscribeFromEvent(IOperationsEvents* eventHandler) override {
        return OperationsBase::SubscribeToEvent(eventHandler);
    }

private:
    std::string wstringToString(std::wstring& wstr);
    long m_refCount;
};

HRESULT __stdcall CreateFileOperations(IFileOperations** result);