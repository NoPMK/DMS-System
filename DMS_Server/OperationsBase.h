#pragma once

#include "IOperationsEvents.h"
#include <vector>

class OperationsBase
{
protected:
	std::vector<IOperationsEvents*> eventHandlers;

	void NotifyEventHandlers(HRESULT(IOperationsEvents::* eventMethod)(BSTR), BSTR path);
	void NotifyEventHandlers(HRESULT(IOperationsEvents::* eventMethod)(BSTR, BSTR), BSTR oldPath, BSTR newPath);

public:
	virtual HRESULT SubscribeToEvent(IOperationsEvents* eventHandler);
	virtual HRESULT UnsubscribeFromEvent(IOperationsEvents* eventHandler);
};