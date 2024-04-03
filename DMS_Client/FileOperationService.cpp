#include "Precompiled.h"
#include "FileOperationService.h"
#include <iostream>
#include <comdef.h> 
#include <string>
#include <sstream> 
#include <objbase.h>


FileOperationService::FileOperationService() {
	InitializeFileOperationsInterface();
	if (pFileOps == nullptr) {
		throw std::runtime_error("Failed to obtain FileOperations interface.");
	}
}

FileOperationService::~FileOperationService() {
}

void FileOperationService::InitializeFileOperationsInterface() {
	CLSID clsid;

	HRESULT hr = CLSIDFromProgID(L"DMSProject.FileOperations", &clsid);
	if (FAILED(hr)) {
		_com_error err(hr);
		std::wstringstream ss;
		ss << L"Failed to get CLSID for FileOperations. Error: " << err.ErrorMessage();
		std::wstring errMsg = ss.str();
		std::wcerr << errMsg << std::endl;
		throw std::runtime_error(std::string(errMsg.begin(), errMsg.end()));
	}

	wchar_t clsidStr[39];
	StringFromGUID2(clsid, clsidStr, 39);
	std::wcout << L"CLSID for FileOperations: " << clsidStr << std::endl;

	hr = CoCreateInstance(clsid, NULL, CLSCTX_INPROC_SERVER, IID_IFileOperations, (void**)&pFileOps);
	if (FAILED(hr)) {
		_com_error err(hr);
		std::wstringstream ss;
		ss << L"Failed to create an instance of FileOperations. HRESULT: " << std::hex << hr << L". Error: " << err.ErrorMessage();
		std::wstring errMsg = ss.str();
		std::wcerr << errMsg << std::endl;
		throw std::runtime_error(std::string(errMsg.begin(), errMsg.end()));
	}
}

void FileOperationService::CreateFile(const std::wstring& filePath) {
	if (pFileOps == nullptr) {
		throw std::runtime_error("FileOperations interface is not available.");
	}
	BSTR bstrFilePath = SysAllocString(filePath.c_str());
	if (bstrFilePath == nullptr) {
		throw std::runtime_error("Failed to allocate BSTR for file path.");
	}

	HRESULT hr = pFileOps->CreateFile(bstrFilePath);
	SysFreeString(bstrFilePath);

	if (SUCCEEDED(hr)) {
		std::cout << "File created successfully." << std::endl;
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
		errMsg = "File creation failed. Error: " + errMsg;
		LocalFree(lpMsgBuf);
		throw std::runtime_error(errMsg);
	}
}

std::wstring FileOperationService::ReadFile(const std::wstring& filePath) {
	if (pFileOps == nullptr) {
		throw std::runtime_error("FileOperations interface is not available.");
	}
	BSTR bstrFilePath = SysAllocString(filePath.c_str());
	if (bstrFilePath == nullptr) {
		throw std::runtime_error("Failed to allocate BSTR for file path.");
	}

	BSTR fileContent = nullptr;
	HRESULT hr = pFileOps->ReadFile(bstrFilePath, &fileContent);
	SysFreeString(bstrFilePath);

	if (SUCCEEDED(hr)) {
		std::wstring content(fileContent, SysStringLen(fileContent));
		SysFreeString(fileContent);
		return content;
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

		std::wstring errMsg = L"Error reading file: " + std::wstring((LPCTSTR)lpMsgBuf);
		LocalFree(lpMsgBuf);
		throw std::runtime_error(std::string(errMsg.begin(), errMsg.end()));
	}
}

void FileOperationService::RenameFile(const std::wstring& filePath, const std::wstring& newContent) {
	if (pFileOps == nullptr) {
		throw std::runtime_error("FileOperations interface is not available.");
	}
	BSTR bstrFilePath = SysAllocString(filePath.c_str());
	BSTR bstrNewContent = SysAllocString(newContent.c_str());

	if (bstrFilePath == nullptr || bstrNewContent == nullptr) {
		if (bstrFilePath != nullptr) {
			SysFreeString(bstrFilePath);
		}
		if (bstrNewContent != nullptr) {
			SysFreeString(bstrNewContent);
		}
		throw std::runtime_error("Failed to allocate BSTR for file path or content.");
	}

	HRESULT hr = pFileOps->RenameFile(bstrFilePath, bstrNewContent);
	SysFreeString(bstrFilePath);
	SysFreeString(bstrNewContent);

	if (FAILED(hr)) {
		std::string errMsg = "Failed to update file. Error code: " + std::to_string(hr);
		throw std::runtime_error(errMsg);
	}
	else {
		std::cout << "File updated successfully." << std::endl;
	}
}

void FileOperationService::DeleteFile(const std::wstring& filePath) {
	if (pFileOps == nullptr) {
		throw std::runtime_error("FileOperations interface is not available.");
	}
	BSTR bstrFilePath = SysAllocString(filePath.c_str());
	if (bstrFilePath == nullptr) {
		throw std::runtime_error("Failed to allocate BSTR for file path.");
	}

	HRESULT hr = pFileOps->DeleteFile(bstrFilePath);
	SysFreeString(bstrFilePath);

	if (FAILED(hr)) {
		std::ostringstream oss;
		oss << hr;
		std::string errMsg = "Failed to delete file. Error code: " + oss.str();
		throw std::runtime_error(errMsg);
	}
	else {
		std::cout << "File deleted successfully." << std::endl;
	}
}

void FileOperationService::MoveFile(const std::wstring& originalFilePath, const std::wstring& newFilePath) {
	if (pFileOps == nullptr) {
		throw std::runtime_error("FileOperations interface is not available.");
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

	HRESULT hr = pFileOps->MoveFile(bstrOriginalPath, bstrNewPath);
	SysFreeString(bstrOriginalPath);
	SysFreeString(bstrNewPath);

	if (FAILED(hr)) {
		std::string errMsg = "Failed to move file. Error code: " + std::to_string(hr);
		throw std::runtime_error(errMsg);
	}
	else {
		std::cout << "File moved successfully." << std::endl;
	}
}