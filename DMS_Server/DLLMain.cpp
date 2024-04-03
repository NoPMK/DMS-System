#include "Precompiled.h"
#include "OperationClassFactory.h"
#include "FileOperations.h"
#include "FolderOperations.h"
#include <new>
#include "Objbase.h"

const int CLSID_STRING_SIZE = 39;

long g_cServerLocks = 0;
long g_cComponents = 0;

const wchar_t* FileOperationsProgID = L"DMSProject.FileOperations";
const wchar_t* FolderOperationsProgID = L"DMSProject.FolderOperations";

HRESULT RegisterCOMClass(const CLSID& clsid, const wchar_t* szProgID, const wchar_t* szModuleName);
HRESULT UnregisterCOMClass(const CLSID& clsid, const wchar_t* szProgID);

BOOL WINAPI DllMain(HINSTANCE hinstDLL, DWORD fdwReason, LPVOID lpvReserved) {
	switch (fdwReason) {
	case DLL_PROCESS_ATTACH:
		OutputDebugString(L"DllMain: DLL_PROCESS_ATTACH\n");
		DisableThreadLibraryCalls(hinstDLL);
		break;
	case DLL_PROCESS_DETACH:
		break;
	case DLL_THREAD_ATTACH:
	case DLL_THREAD_DETACH:
		OutputDebugString(L"DllMain: DLL_PROCESS_DETACH\n");
		break;
	}
	return TRUE;
}

HMODULE GetCurrentModule()
{
	HMODULE hModule = NULL;
	GetModuleHandleEx(GET_MODULE_HANDLE_EX_FLAG_FROM_ADDRESS, (LPCTSTR)GetCurrentModule, &hModule);

	return hModule;
}

extern "C" HRESULT __stdcall DllRegisterServer() {
	OutputDebugString(L"DllRegisterServer: Entry\n");

	wchar_t szModulePath[MAX_PATH];

	if (GetModuleFileName(GetCurrentModule(), szModulePath, MAX_PATH) == 0) {
		return HRESULT_FROM_WIN32(GetLastError());
	}

	OutputDebugString(szModulePath);

	HRESULT hrFile = RegisterCOMClass(CLSID_FileOperations, FileOperationsProgID, szModulePath);
	HRESULT hrFolder = RegisterCOMClass(CLSID_FolderOperations, FolderOperationsProgID, szModulePath);

	OutputDebugString(L"DllRegisterServer: Exit\n");
	return SUCCEEDED(hrFile) && SUCCEEDED(hrFolder) ? S_OK : E_FAIL;
}

extern "C" HRESULT __stdcall DllUnregisterServer() {
	HRESULT hrFile = UnregisterCOMClass(CLSID_FileOperations, FileOperationsProgID);
	HRESULT hrFolder = UnregisterCOMClass(CLSID_FolderOperations, FolderOperationsProgID);

	return SUCCEEDED(hrFile) && SUCCEEDED(hrFolder) ? S_OK : E_FAIL;
}

template <typename T>
HRESULT CreateClassObject(REFIID iid, void** result) {
	OutputDebugString(L"CreateClassObject: Entry\n");
	auto* pFactory = new (std::nothrow) OperationClassFactory<T>();
	if (!pFactory) {
		OutputDebugString(L"CreateClassObject: Factory creation failed\n");
		return E_OUTOFMEMORY;
	}

	HRESULT hr = pFactory->QueryInterface(iid, result);
	pFactory->Release();

	OutputDebugString(L"CreateClassObject: Exit\n");
	return hr;
}

extern "C" HRESULT __stdcall DllGetClassObject(
	_In_ REFCLSID clsid,
	_In_ REFIID iid,
	_COM_Outptr_ void** result) {

	ASSERT(result);
	*result = nullptr;

	if (clsid == CLSID_FileOperations) {
		return CreateClassObject<FileOperations>(iid, result);
	}
	else if (clsid == CLSID_FolderOperations) {
		return CreateClassObject<FolderOperations>(iid, result);
	}

	return CLASS_E_CLASSNOTAVAILABLE;
}

extern "C" HRESULT __stdcall DllCanUnloadNow() {
	return (g_cComponents == 0 && g_cServerLocks == 0) ? S_OK : S_FALSE;
}

HRESULT RegisterCOMClass(const CLSID& clsid, const wchar_t* szProgID, const wchar_t* szModuleName) {
	wchar_t clsidStr[CLSID_STRING_SIZE];
	StringFromGUID2(clsid, clsidStr, CLSID_STRING_SIZE);

	wchar_t subKey[MAX_PATH];
	HKEY hKey, hSubKey;
	LONG lResult;

	// Register the CLSID
	swprintf_s(subKey, MAX_PATH, L"CLSID\\%s", clsidStr);
	lResult = RegCreateKeyEx(HKEY_CLASSES_ROOT, subKey, 0, NULL, REG_OPTION_NON_VOLATILE, KEY_WRITE, NULL, &hKey, NULL);
	if (lResult != ERROR_SUCCESS) {
		return HRESULT_FROM_WIN32(lResult);
	}

	// Set the default value to the description
	OutputDebugString(szModuleName);

	RegSetValueEx(hKey, NULL, 0, REG_SZ, (const BYTE*)szModuleName, (DWORD)(wcslen(szModuleName) + 1) * sizeof(wchar_t));

	// Create InProcServer32 key
	lResult = RegCreateKeyEx(hKey, L"InProcServer32", 0, NULL, REG_OPTION_NON_VOLATILE, KEY_WRITE, NULL, &hSubKey, NULL);
	if (lResult == ERROR_SUCCESS) {
		RegSetValueEx(hSubKey, NULL, 0, REG_SZ, (const BYTE*)szModuleName, (DWORD)(wcslen(szModuleName) + 1) * sizeof(wchar_t));
		const wchar_t* threadingModel = L"Apartment";
		RegSetValueEx(hSubKey, L"ThreadingModel", 0, REG_SZ, (const BYTE*)threadingModel, (DWORD)(wcslen(threadingModel) + 1) * sizeof(wchar_t));
		RegCloseKey(hSubKey);
	}

	RegCloseKey(hKey);

	// Register the ProgID
	lResult = RegCreateKeyEx(HKEY_CLASSES_ROOT, szProgID, 0, NULL, REG_OPTION_NON_VOLATILE, KEY_WRITE, NULL, &hKey, NULL);
	if (lResult != ERROR_SUCCESS) {
		return HRESULT_FROM_WIN32(lResult);
	}

	// Set the default value of the key to the CLSID
	RegSetValueEx(hKey, NULL, 0, REG_SZ, (const BYTE*)clsidStr, (DWORD)(wcslen(clsidStr) + 1) * sizeof(wchar_t));

	// Create CLSID subkey under the ProgID key
	lResult = RegCreateKeyEx(hKey, L"CLSID", 0, NULL, REG_OPTION_NON_VOLATILE, KEY_WRITE, NULL, &hSubKey, NULL);
	if (lResult == ERROR_SUCCESS) {
		RegSetValueEx(hSubKey, NULL, 0, REG_SZ, (const BYTE*)clsidStr, (DWORD)(wcslen(clsidStr) + 1) * sizeof(wchar_t));
		RegCloseKey(hSubKey);
	}

	RegCloseKey(hKey);

	return S_OK;
}

HRESULT UnregisterCOMClass(const CLSID& clsid, const wchar_t* szProgID) {
	wchar_t clsidStr[CLSID_STRING_SIZE];
	StringFromGUID2(clsid, clsidStr, CLSID_STRING_SIZE);

	wchar_t subKey[MAX_PATH];
	LONG lResult;
	HRESULT hr = S_OK;

	// Delete the ProgID key
	lResult = RegDeleteTree(HKEY_CLASSES_ROOT, szProgID);
	if (lResult != ERROR_SUCCESS && lResult != ERROR_FILE_NOT_FOUND) {
		hr = HRESULT_FROM_WIN32(lResult);
	}

	// Delete the CLSID key
	swprintf_s(subKey, MAX_PATH, L"CLSID\\%s", clsidStr);
	lResult = RegDeleteTree(HKEY_CLASSES_ROOT, subKey);
	if (lResult != ERROR_SUCCESS && lResult != ERROR_FILE_NOT_FOUND) {
		hr = HRESULT_FROM_WIN32(lResult);
	}

	return hr;
}