using CStudio.Core.Models;
using CStudio.Core.Services;

namespace CStudio.Mock;

public sealed class MockLogService : ILogService
{
    private readonly MockWorkspaceProfile _profile;

    public MockLogService()
        : this(MockWorkspaceProfiles.CreateDefault())
    {
    }

    public MockLogService(MockWorkspaceProfile profile)
    {
        _profile = profile;
    }

    public IReadOnlyList<LogEntry> GetLogs() => _profile.Logs;
}
