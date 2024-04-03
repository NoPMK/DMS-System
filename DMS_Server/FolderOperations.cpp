#include "Precompiled.h"
#include "FolderOperations.h"
#include <iostream>
#include <filesystem>
#include <algorithm>

#define ASSERT _ASSERT

using namespace std;

FolderOperations::FolderOperations() : OperationsBase(), m_refCount(1) {
	cout << "FolderOperations Initialized\n";
}

FolderOperations::~FolderOperations() {
	cout << "FolderOperations Destroyed\n";
}

ULONG __stdcall FolderOperations::AddRef() {
	return InterlockedIncrement(&m_refCount);
}

ULONG __stdcall FolderOperations::Release() {
	ULONG newRefCount = InterlockedDecrement(&m_refCount);
	if (newRefCount == 0) {
		delete this;
	}
	return newRefCount;
}

HRESULT __stdcall FolderOperations::QueryInterface(REFIID riid, void** result) {
	if (!result) {
		return E_INVALIDARG;
	}

	*result = nullptr;

	if (riid == IID_IUnknown || riid == __uuidof(IFolderOperations)) {
		*result = static_cast<IFolderOperations*>(this);
	}
	else {
		return E_NOINTERFACE;
	}

	static_cast<IUnknown*>(*result)->AddRef();
	return S_OK;
}

HRESULT __stdcall FolderOperations::CreateFolder(const BSTR path) {
	if (path == nullptr) {
		return E_INVALIDARG;
	}

	wstring wFilePath(path, SysStringLen(path));

	try {
		bool created = std::filesystem::create_directory(wFilePath);

		if (!created && std::filesystem::exists(wFilePath)) {
			return E_FAIL;
		}

		NotifyEventHandlers(&IOperationsEvents::OnFolderCreated, path);
	}
	catch (const std::filesystem::filesystem_error& e) {
		if (e.code() == std::make_error_code(std::errc::file_exists)) {
			return HRESULT_FROM_WIN32(ERROR_ALREADY_EXISTS);
		}
		return HRESULT_FROM_WIN32(GetLastError());
	}

	return S_OK;
}

HRESULT __stdcall FolderOperations::DeleteFolder(const BSTR path) {
	if (path == nullptr) {
		return E_INVALIDARG;
	}

	wstring wFilePath(path, SysStringLen(path));

	try {
		std::filesystem::remove_all(wFilePath);

		NotifyEventHandlers(&IOperationsEvents::OnFolderDeleted, path);
	}
	catch (const std::filesystem::filesystem_error& e) {
		return HRESULT_FROM_WIN32(GetLastError());
	}

	return S_OK;
}

HRESULT __stdcall FolderOperations::RenameFolder(const BSTR originalFilePath, BSTR newFolderName) {
	if (originalFilePath == nullptr || newFolderName == nullptr) {
		return E_INVALIDARG;
	}

	std::filesystem::path originalPath(originalFilePath);
	std::filesystem::path newPath = originalPath.parent_path() / newFolderName;

	try {
		if (filesystem::exists(newPath)) {
			throw std::runtime_error("New folder name already exists.");
		}

		std::filesystem::rename(originalPath, newPath);

		NotifyEventHandlers(&IOperationsEvents::OnFolderRenamed, originalFilePath, newFolderName);
	}
	catch (const std::filesystem::filesystem_error& e) {
		return HRESULT_FROM_WIN32(GetLastError());
	}

	return S_OK;
}

HRESULT __stdcall FolderOperations::MoveFolder(const BSTR originalFilePath, BSTR newFilePath) {
	if (originalFilePath == nullptr || newFilePath == nullptr) {
		return E_INVALIDARG;
	}

	try {
		std::filesystem::path srcPath(originalFilePath);
		std::filesystem::path destPath(newFilePath);
		std::filesystem::rename(srcPath, destPath);

		NotifyEventHandlers(&IOperationsEvents::OnFolderMoved, originalFilePath, newFilePath);
	}
	catch (const std::filesystem::filesystem_error& e) {
		return HRESULT_FROM_WIN32(GetLastError());
	}

	return S_OK;
}

HRESULT __stdcall FolderOperations::CopyFolder(const BSTR originalFilePath, BSTR newFilePath) {
	if (originalFilePath == nullptr || newFilePath == nullptr) {
		return E_INVALIDARG;
	}

	try {
		std::filesystem::path srcPath(originalFilePath);
		std::filesystem::path destPath(newFilePath);
	    std::filesystem::copy(srcPath, newFilePath);

		NotifyEventHandlers(&IOperationsEvents::OnFolderCopied, originalFilePath, newFilePath);
	}
	catch (const std::filesystem::filesystem_error& e) {
		return HRESULT_FROM_WIN32(GetLastError());
	}
}

HRESULT __stdcall FolderOperations::OpenFolder(const BSTR filePath) {
	if (filePath == nullptr) {
		return E_INVALIDARG;
	}

	NotifyEventHandlers(&IOperationsEvents::OnFolderOpened, filePath);

	return S_OK;
}

HRESULT __stdcall CreateFolderOperations(IFolderOperations** result) {
	ASSERT(result);

	*result = new (std::nothrow) FolderOperations;


	if (*result == 0) {
		return E_OUTOFMEMORY;
	}

	(*result)->AddRef();
	return S_OK;
}