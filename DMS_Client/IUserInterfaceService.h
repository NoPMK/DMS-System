#pragma once
#include "Precompiled.h"

class IUserInterfaceService {
public:
    virtual void Run() = 0;
    virtual ~IUserInterfaceService() {}
};