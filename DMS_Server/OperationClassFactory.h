#pragma once

#include "Precompiled.h"
#include "FileOperations.h"
#include "FolderOperations.h"
#include "ServerStateManager.h"
#include <wrl.h>
#include <atomic>
#include <unknwn.h>

using namespace Microsoft::WRL;

template <typename T>
struct __declspec(uuid("6fcf2c10-cc76-4e86-a5af-99eebed251ab"))
    OperationClassFactory : public IClassFactory
{
public:
    OperationClassFactory() : m_refCount(1) {}

    virtual ~OperationClassFactory() {}

    // IUnknown Methods
    HRESULT __stdcall QueryInterface(REFIID riid, void** ppvObject) override {
        if (riid == IID_IUnknown || riid == IID_IClassFactory) {
            *ppvObject = static_cast<IClassFactory*>(this);
            this->AddRef();
            return S_OK;
        }
        *ppvObject = nullptr;
        return E_NOINTERFACE;
    }

    ULONG __stdcall AddRef() override {
        return m_refCount.fetch_add(1) + 1;
    }

    ULONG __stdcall Release() override {
        ULONG newRefCount = m_refCount.fetch_sub(1) - 1;
        if (newRefCount == 0) {
            delete this;
        }
        return newRefCount;
    }

    // IClassFactory Methods
    HRESULT __stdcall CreateInstance(IUnknown* pUnkOuter, REFIID riid, void** ppvObject) override {
        if (pUnkOuter != nullptr) {
            return CLASS_E_NOAGGREGATION;
        }

        T* pOps = new (std::nothrow) T();
        if (pOps == nullptr) {
            return E_OUTOFMEMORY;
        }

        HRESULT hr = pOps->QueryInterface(riid, ppvObject);
        pOps->Release();
        return hr;
    }

    HRESULT __stdcall LockServer(BOOL fLock) override {
        ServerStateManager& stateManager = ServerStateManager::Instance();
        if (fLock) {
            stateManager.IncrementLocks();
        }
        else {
            stateManager.DecrementLocks();
        }
        return S_OK;
    }

private:
    std::atomic<ULONG> m_refCount;
};
