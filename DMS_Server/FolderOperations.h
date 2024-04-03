#pragma once

#include "DMS_Server_h.h"
#include "IOperationsEvents.h"
#include "OperationsBase.h"
#include <Windows.h>
#include <unknwn.h>

interface IOperationsEvents;

class FolderOperations : public IFolderOperations, public OperationsBase
{
public:
	FolderOperations();
	virtual ~FolderOperations();

	// IUnknown methods
	HRESULT __stdcall QueryInterface(REFIID riid, void** ppvObject) override;
	ULONG __stdcall AddRef() override;
	ULONG __stdcall Release() override;

	// IFolderOperation methods
	HRESULT __stdcall CreateFolder(const BSTR filePath) override;
	HRESULT __stdcall DeleteFolder(const BSTR filePath) override;
	HRESULT __stdcall RenameFolder(const BSTR originalFilePath, BSTR newFolderName) override;
	HRESULT __stdcall MoveFolder(const BSTR originalFilePath, BSTR newFilePath) override;
	HRESULT __stdcall OpenFolder(const BSTR filePath) override;
	HRESULT __stdcall CopyFolder(const BSTR originalFilePath, BSTR newFilePath) override;


	HRESULT __stdcall SubscribeToEvent(IOperationsEvents* eventHandler) override {
		return OperationsBase::SubscribeToEvent(eventHandler);
	}
	HRESULT __stdcall UnsubscribeFromEvent(IOperationsEvents* eventHandler) override {
		return OperationsBase::SubscribeToEvent(eventHandler);
	}

private:
	long m_refCount;

};

HRESULT __stdcall CreateFolderOperations(IFolderOperations** folderOps);