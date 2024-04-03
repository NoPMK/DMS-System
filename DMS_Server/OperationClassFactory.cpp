#include "Precompiled.h"
//#include "OperationClassFactory.h"
//#include <guiddef.h>
//#include <wrl.h>
//#include <iostream>
//#include <fstream>
//#include <crtdbg.h>
//#include <Filesystem>
//#include <locale>
//#include <codecvt>
//#include "ServerStateManager.h"
//
//using namespace Microsoft::WRL;
//using namespace std;
//
//// Constructor
//template <typename T>
//OperationClassFactory<T>::OperationClassFactory() : m_refCount(1) {}
//
//// Destructor
//template <typename T>
//OperationClassFactory<T>::~OperationClassFactory() {}
//
//// IUnknown methods
//template <typename T>
//HRESULT __stdcall OperationClassFactory<T>::QueryInterface(REFIID riid, void** ppv) {
//    if (riid == IID_IUnknown || riid == IID_IClassFactory) {
//        *ppv = static_cast<IClassFactory*>(this);
//        this->AddRef();
//        return S_OK;
//    }
//    *ppv = nullptr;
//    return E_NOINTERFACE;
//}
//
//template <typename T>
//ULONG __stdcall OperationClassFactory<T>::AddRef() {
//    return m_refCount.fetch_add(1) + 1;
//}
//
//template <typename T>
//ULONG __stdcall OperationClassFactory<T>::Release() {
//    ULONG newRefCount = m_refCount.fetch_sub(1) - 1;
//    if (newRefCount == 0) {
//        delete this;
//    }
//    return newRefCount;
//}
//
//
//// IClassFactory methods
//template <typename T>
//HRESULT __stdcall OperationClassFactory<T>::CreateInstance(IUnknown* pUnkOuter, REFIID riid, void** ppv) {
//    if (pUnkOuter != nullptr) {
//        return CLASS_E_NOAGGREGATION;
//    }
//
//    T* pOps = new (std::nothrow) T();
//    if (pOps == nullptr) {
//        return E_OUTOFMEMORY;
//    }
//
//    HRESULT hr = pOps->QueryInterface(riid, ppv);
//    pOps->Release();
//    return hr;
//}
//
//template <typename T>
//HRESULT __stdcall OperationClassFactory<T>::LockServer(BOOL fLock) {
//    ServerStateManager& stateManager = ServerStateManager::Instance();
//    if (fLock) {
//        stateManager.IncrementLocks();
//    }
//    else {
//        stateManager.DecrementLocks();
//    }
//    return S_OK;
//}