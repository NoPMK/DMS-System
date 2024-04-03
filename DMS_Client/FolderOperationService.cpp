#include "Precompiled.h"
#include "FolderOperationService.h"
#include <iostream>
#include <comdef.h> 
#include <string>
#include <sstream> 

FolderOperationService::FolderOperationService() {
	InitializeFolderOperationInterface();
	if (pFolderOps == nullptr) {
		throw std::runtime_error("Failed to obtain FolderOperations interface");
	}
}

FolderOperationService::~FolderOperationService() {
}

void FolderOperationService::InitializeFolderOperationInterface() {
	CLSID clsid;
	HRESULT hr = CLSIDFromProgID(L"DMSProject.FolderOperations", &clsid);
	if (FAILED(hr)) {
		if (FAILED(hr)) {
			_com_error err(hr);
			std::wstringstream ss;
			ss << L"Failed to get CLSID for FolderOperations. Error: " << err.ErrorMessage();
			std::wstring errMsg = ss.str();
			std::wcerr << errMsg << std::endl;
			throw std::runtime_error(std::string(errMsg.begin(), errMsg.end()));
		}
	}

	wchar_t clsidStr[39];
	StringFromGUID2(clsid, clsidStr, 39);
	std::wcout << L"CLSID for FolderOperations: " << clsidStr << std::endl;

	hr = CoCreateInstance(clsid, NULL, CLSCTX_INPROC_SERVER, IID_IFolderOperations, (void**)&pFolderOps);
	if (FAILED(hr)) {
		_com_error err(hr);
		std::wstringstream ss;
		ss << L"Failed to create an instance of FolderOperations. HRESULT: " << std::hex << hr << L". Error: " << err.ErrorMessage();
		std::wstring errMsg = ss.str();
		std::wcerr << errMsg << std::endl;
		throw std::runtime_error(std::string(errMsg.begin(), errMsg.end()));
	}
}

void FolderOperationService::CreateFolder(const std::wstring& filePath) {
	if (pFolderOps == nullptr) {
		throw std::runtime_error("FolderOperations interface is not available.");
	}
	BSTR bstrFilePath = SysAllocString(filePath.c_str());
	if (bstrFilePath == nullptr) {
		throw std::runtime_error("Failed to allocate BSTR for file path.");
	}

	HRESULT hr = pFolderOps->CreateFolder(bstrFilePath);
	SysFreeString(bstrFilePath);

	if (SUCCEEDED(hr)) {
		std::cout << "Folder created successfully." << std::endl;
	}
	else {
		LPVOID lpMsgBuf;
		FormatMessage(
			FORMAT_MESSAGE_ALLOCATE_BUFFER |
			FORMAT_MESSAGE_FROM_SYSTEM |
			FORMAT_MESSAGE_IGNORE_INSERTS,
			NULL,
			hr,
			MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT),
			(LPTSTR)&lpMsgBuf,
			0, NULL);

		int len = WideCharToMultiByte(CP_UTF8, 0, (LPCTSTR)lpMsgBuf, -1, nullptr, 0, nullptr, nullptr);
		std::string errMsg(len, '\0');
		WideCharToMultiByte(CP_UTF8, 0, (LPCTSTR)lpMsgBuf, -1, &errMsg[0], len, nullptr, nullptr);
		errMsg = "Folder creation failed. Error: " + errMsg;
		LocalFree(lpMsgBuf);
		throw std::runtime_error(errMsg);
	}
}

void FolderOperationService::DeleteFolder(const std::wstring& filePath) {
	if (pFolderOps == nullptr) {
		throw std::runtime_error("FolderOperations interface is not available.");
	}
	BSTR bstrFilePath = SysAllocString(filePath.c_str());
	if (bstrFilePath == nullptr) {
		throw std::runtime_error("Failed to allocate BSTR for file path.");
	}

	HRESULT hr = pFolderOps->DeleteFolder(bstrFilePath);
	SysFreeString(bstrFilePath);

	if (FAILED(hr)) {
		std::ostringstream oss;
		oss << hr;
		std::string errMsg = "Failed to delete folder. Error code: " + oss.str();
		throw std::runtime_error(errMsg);
	}
	else {
		std::cout << "Folder deleted successfully." << std::endl;
	}
}

void FolderOperationService::RenameFolder(const std::wstring& originalFilePath, const std::wstring& newFolderName) {
	if (pFolderOps == nullptr) {
		throw std::runtime_error("FolderOperations interface is not available.");
	}
	BSTR bstrFilePath = SysAllocString(originalFilePath.c_str());
	BSTR bstrNewName = SysAllocString(newFolderName.c_str());

	if (bstrFilePath == nullptr || bstrNewName == nullptr) {
		if (bstrFilePath != nullptr) {
			SysFreeString(bstrFilePath);
		}
		if (bstrNewName != nullptr) {
			SysFreeString(bstrNewName);
		}
		throw std::runtime_error("Failed to allocate BSTR for file path or content.");
	}

	HRESULT hr = pFolderOps->RenameFolder(bstrFilePath, bstrNewName);
	SysFreeString(bstrFilePath);
	SysFreeString(bstrNewName);

	if (FAILED(hr)) {
		std::string errMsg = "Failed to rename folder. Error code: " + std::to_string(hr);
		throw std::runtime_error(errMsg);
	}
	else {
		std::cout << "Folder renamed successfully." << std::endl;
	}
}

void FolderOperationService::MoveFolder(const std::wstring& originalFilePath, const std::wstring& newFilePath) {
	if (pFolderOps == nullptr) {
		throw std::runtime_error("FolderOperations interface is not available.");
	}
	BSTR bstrOriginalPath = SysAllocString(originalFilePath.c_str());
	BSTR bstrNewPath = SysAllocString(newFilePath.c_str());

	if (bstrOriginalPath == nullptr || bstrNewPath == nullptr) {
		if (bstrOriginalPath != nullptr) {
			SysFreeString(bstrOriginalPath);
		}
		if (bstrNewPath != nullptr) {
			SysFreeString(bstrNewPath);
		}
		throw std::runtime_error("Failed to allocate BSTR for file path or content.");
	}

	HRESULT hr = pFolderOps->MoveFolder(bstrOriginalPath, bstrNewPath);
	SysFreeString(bstrOriginalPath);
	SysFreeString(bstrNewPath);

	if (FAILED(hr)) {
		std::string errMsg = "Failed to move folder. Error code: " + std::to_string(hr);
		throw std::runtime_error(errMsg);
	}
	else {
		std::cout << "Folder moved successfully." << std::endl;
	}
}

void FolderOperationService::OpenFolder(const std::wstring& filePath) {
	if (pFolderOps == nullptr) {
		throw std::runtime_error("FileOperations interface is not available.");
	}
	BSTR bstrFilePath = SysAllocString(filePath.c_str());
	if (bstrFilePath == nullptr) {
		throw std::runtime_error("Failed to allocate BSTR for file path.");
	}

	HRESULT hr = pFolderOps->OpenFolder(bstrFilePath);
	SysFreeString(bstrFilePath);

	if (FAILED(hr)) {
		LPVOID lpMsgBuf;
		FormatMessage(
			FORMAT_MESSAGE_ALLOCATE_BUFFER |
			FORMAT_MESSAGE_FROM_SYSTEM |
			FORMAT_MESSAGE_IGNORE_INSERTS,
			NULL,
			hr,
			MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT),
			(LPTSTR)&lpMsgBuf,
			0, NULL);

		std::wstring errMsg = L"Error opening folder: " + std::wstring((LPCTSTR)lpMsgBuf);
		LocalFree(lpMsgBuf);
		throw std::runtime_error(std::string(errMsg.begin(), errMsg.end()));
	}
}