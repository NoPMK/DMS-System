#include "Precompiled.h"
#include "FileOperations.h"
#include <iostream>
#include <fstream>
#include <crtdbg.h>
#include <filesystem>

#define ASSERT _ASSERT

using namespace std;


FileOperations::FileOperations() : m_refCount(1) {
	cout << "FileOperations Initialized\n";
}

FileOperations::~FileOperations() {
	cout << "FileOperations Destroyed\n";
}

ULONG __stdcall FileOperations::AddRef() {
	return InterlockedIncrement(&m_refCount);
}

ULONG __stdcall FileOperations::Release() {
	ULONG newRefCount = InterlockedDecrement(&m_refCount);
	if (newRefCount == 0) {
		delete this;
	}
	return newRefCount;
}

HRESULT __stdcall FileOperations::QueryInterface(REFIID riid, void** result) {
	if (!result) {
		return E_INVALIDARG;
	}

	*result = nullptr;

	if (riid == IID_IUnknown || riid == __uuidof(IFileOperations)) {
		*result = static_cast<IFileOperations*>(this);
	}
	else {
		return E_NOINTERFACE;
	}

	static_cast<IUnknown*>(*result)->AddRef();
	return S_OK;
}

HRESULT __stdcall FileOperations::CreateFile(const BSTR filePath) {
	if (filePath == nullptr) {
		return E_INVALIDARG;
	}

	wstring wFilePath(filePath, SysStringLen(filePath));

	if (filesystem::exists(wFilePath)) {
		return HRESULT_FROM_WIN32(ERROR_FILE_EXISTS);
	}

	HANDLE hFile = ::CreateFile(
		wFilePath.c_str(),
		GENERIC_WRITE,
		0,
		NULL,
		CREATE_NEW,
		FILE_ATTRIBUTE_NORMAL,
		NULL);

	if (hFile == INVALID_HANDLE_VALUE) {
		return HRESULT_FROM_WIN32(GetLastError());
	}

	CloseHandle(hFile);

	NotifyEventHandlers(&IOperationsEvents::OnFileCreated, filePath);
	return S_OK;
}

HRESULT __stdcall FileOperations::DeleteFile(const BSTR filePath) {
	if (filePath == nullptr) {
		return E_INVALIDARG;
	}

	wstring wFilePath(filePath, SysStringLen(filePath));

	if (!filesystem::remove(wFilePath)) {
		return HRESULT_FROM_WIN32(GetLastError());
	}

	NotifyEventHandlers(&IOperationsEvents::OnFileDeleted, filePath);
	return S_OK;
}

HRESULT __stdcall FileOperations::ReadFile(const BSTR filePath) {
	if (filePath == nullptr) {
		return E_INVALIDARG;
	}

	wstring wFilePath(filePath, SysStringLen(filePath));

	HINSTANCE result = ShellExecute(NULL, L"open", wFilePath.c_str(), NULL, NULL, SW_SHOWNORMAL);

	if ((int)result <= 32) {
		return HRESULT_FROM_WIN32(GetLastError());
	}

	NotifyEventHandlers(&IOperationsEvents::OnFileRead, filePath);

	return S_OK;
}


HRESULT __stdcall FileOperations::RenameFile(const BSTR originalFilePath, BSTR newFileName) {
	if (originalFilePath == nullptr) {
		return E_INVALIDARG;
	}

	std::filesystem::path originalPath(originalFilePath);
	std::filesystem::path newFilePath = originalPath.parent_path() / std::filesystem::path(newFileName);

	try {
		if (std::filesystem::exists(newFilePath)) {
			return HRESULT_FROM_WIN32(ERROR_ALREADY_EXISTS);
		}

		std::filesystem::rename(originalPath, newFilePath);

		NotifyEventHandlers(&IOperationsEvents::OnFileRenamed, originalFilePath, newFileName);
	}
	catch (const std::filesystem::filesystem_error& e) {
		return HRESULT_FROM_WIN32(GetLastError());
	}
	return S_OK;
}

HRESULT __stdcall FileOperations::MoveFile(const BSTR originalFilePath, BSTR newFilePath) {
	if (originalFilePath == nullptr || newFilePath == nullptr) {
		return E_INVALIDARG;
	}

	try {
		std::filesystem::path srcPath(originalFilePath);
		std::filesystem::path destPath(newFilePath);
		std::filesystem::rename(srcPath, destPath);

		NotifyEventHandlers(&IOperationsEvents::OnFileMoved, originalFilePath, newFilePath);
	}
	catch (const std::filesystem::filesystem_error& e) {
		return HRESULT_FROM_WIN32(GetLastError());
	}

	return S_OK;
}

HRESULT __stdcall FileOperations::CopyFile(const BSTR originalFilePath, BSTR newFilePath) {
	if (originalFilePath == nullptr || newFilePath == nullptr) {
		return E_INVALIDARG;
	}

	try {
		std::filesystem::path srcPath(originalFilePath);
		std::filesystem::path destPath(newFilePath);

		std::filesystem::copy_file(srcPath, destPath);

		NotifyEventHandlers(&IOperationsEvents::OnFileCopied, originalFilePath, newFilePath);
	}
	catch (const std::filesystem::filesystem_error& e) {
		return HRESULT_FROM_WIN32(GetLastError());
	}

	return S_OK;
}

std::string FileOperations::wstringToString(std::wstring& wstr) {
	if (wstr.empty()) {
		return std::string();
	}
	int sizeNeeded = WideCharToMultiByte(CP_UTF8, 0, &wstr[0], (int)wstr.size(), NULL, 0, NULL, NULL);
	std::string strTo(sizeNeeded, 0);
	WideCharToMultiByte(CP_UTF8, 0, &wstr[0], (int)wstr.size(), &strTo[0], sizeNeeded, NULL, NULL);
	return strTo;
}

HRESULT __stdcall CreateFileOperations(IFileOperations** result) {
	ASSERT(result);

	*result = new (std::nothrow) FileOperations;

	if (*result == 0) {
		return E_OUTOFMEMORY;
	}

	(*result)->AddRef();
	return S_OK;
}