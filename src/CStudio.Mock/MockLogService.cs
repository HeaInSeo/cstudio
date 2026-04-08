using CStudio.Core.Models;
using CStudio.Core.Services;

namespace CStudio.Mock;

public sealed class MockLogService : ILogService
{
    public IReadOnlyList<LogEntry> GetLogs()
    {
        return
        [
            new LogEntry("INFO", "CStudio shell initialized", "09:00:01"),
            new LogEntry("INFO", "Mock workspace loaded", "09:00:02"),
            new LogEntry("WARN", "Runtime adapter not connected", "09:00:03"),
            new LogEntry("INFO", "GPU-Reshape inspired layout active", "09:00:04"),
            new LogEntry("INFO", "Sprint 01 shell parity pass applied", "09:00:05"),
            new LogEntry("INFO", "Sprint 02 shell contract services active", "09:00:06")
        ];
    }
}
