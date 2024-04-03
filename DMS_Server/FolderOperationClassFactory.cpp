//#include "Precompiled.h"
//#include "FolderOperationClassFactory.h"
//#include "FileOperations.h"
//#include <guiddef.h>
//#include <wrl.h>
//#include <iostream>
//#include <fstream>
//#include <crtdbg.h>
//#include <filesystem>
//#include <locale>
//#include <codecvt>
//#include "ServerStateManager.h"
//
//using namespace Microsoft::WRL;
//using namespace std;
//
//// Constructor
//FolderOperationClassFactory::FileOperationClassFactory() : m_refCount(1) {}
//
//// Destructor
//FileOperationClassFactory::~FileOperationClassFactory() {}
//
//// IUnknown methods
//HRESULT __stdcall FileOperationClassFactory::QueryInterface(REFIID riid, void** ppv) {
//    if (riid == IID_IUnknown || riid == IID_IClassFactory) {
//        *ppv = static_cast<IClassFactory*>(this);
//        this->AddRef();
//        return S_OK;
//    }
//    *ppv = nullptr;
//    return E_NOINTERFACE;
//}
//
//ULONG __stdcall FileOperationClassFactory::AddRef() {
//    return m_refCount.fetch_add(1) + 1;
//}
//
//
//ULONG __stdcall FileOperationClassFactory::Release() {
//    ULONG newRefCount = m_refCount.fetch_sub(1) - 1;
//    if (newRefCount == 0) {
//        delete this;
//    }
//    return newRefCount;
//}
//
//
//// IClassFactory methods
//HRESULT __stdcall FileOperationClassFactory::CreateInstance(IUnknown* pUnkOuter, REFIID riid, void** ppv) {
//    if (pUnkOuter != nullptr) {
//        return CLASS_E_NOAGGREGATION;
//    }
//
//    FileOperations* pFileOps = new (std::nothrow) FileOperations();
//    if (pFileOps == nullptr) {
//        return E_OUTOFMEMORY;
//    }
//
//    HRESULT hr = pFileOps->QueryInterface(riid, ppv);
//    pFileOps->Release();
//    return hr;
//}
//
//HRESULT __stdcall FileOperationClassFactory::LockServer(BOOL fLock) {
//    ServerStateManager& stateManager = ServerStateManager::Instance();
//    if (fLock) {
//        stateManager.IncrementLocks();
//    }
//    else {
//        stateManager.DecrementLocks();
//    }
//    return S_OK;
//}