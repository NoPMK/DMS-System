// ServerState.h
#pragma once

#include <atomic>

class ServerStateManager {
private:
    std::atomic<long> m_cServerLocks{ 0 };
    std::atomic<long> m_cComponents{ 0 };

    ServerStateManager() = default;

public:
    // Singleton access
    static ServerStateManager& Instance() {
        static ServerStateManager instance;
        return instance;
    }

    // Delete copy and move constructors and assign operators
    ServerStateManager(ServerStateManager const&) = delete;
    ServerStateManager(ServerStateManager&&) = delete;
    ServerStateManager& operator=(ServerStateManager const&) = delete;
    ServerStateManager& operator=(ServerStateManager&&) = delete;   
    // Methods to manipulate server state
    void IncrementLocks() { m_cServerLocks++; }
    void DecrementLocks() { m_cServerLocks--; }
    void IncrementComponents() { m_cComponents++; }
    void DecrementComponents() { m_cComponents--; }
    bool CanUnloadNow() const { return m_cServerLocks == 0 && m_cComponents == 0; }
};