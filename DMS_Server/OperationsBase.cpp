#include "Precompiled.h"
#include "DMS_Server_h.h"
#include "OperationsBase.h"
#include <algorithm>


HRESULT __stdcall OperationsBase::SubscribeToEvent(IOperationsEvents* eventHandler)
{
	if (!eventHandler) {
		return E_POINTER;
	}

	try {
		eventHandler->AddRef();
		eventHandlers.push_back(eventHandler);

	}
	catch (const std::bad_alloc&) {
		eventHandler->Release();
		return E_OUTOFMEMORY;
	}
	catch (...) {
		eventHandler->Release();
		return E_FAIL;
	}
	return S_OK;
}

HRESULT __stdcall OperationsBase::UnsubscribeFromEvent(IOperationsEvents* eventHandler)
{
	if (!eventHandler) {
		return E_POINTER;
	}

	auto it = std::find(eventHandlers.begin(), eventHandlers.end(), eventHandler);
	if (it != eventHandlers.end()) {
		eventHandlers.erase(it);
		eventHandler->Release();
		return S_OK;
	}
	return E_FAIL;
}

void OperationsBase::NotifyEventHandlers(HRESULT(IOperationsEvents::* eventMethod)(BSTR), BSTR path)
{
	for (auto handler : eventHandlers)
	{
		(handler->*eventMethod)(path);
	}
}

void OperationsBase::NotifyEventHandlers(HRESULT(IOperationsEvents::* eventMethod)(BSTR, BSTR), BSTR originalPath, BSTR newPath)
{
	for (auto handler : eventHandlers)
	{
		(handler->*eventMethod)(originalPath, newPath);
	}
}