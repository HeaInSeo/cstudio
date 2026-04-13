using CStudio.Core.Models;
using CStudio.Core.Services;

namespace CStudio.Mock;

public sealed class MockWorkspaceService : IWorkspaceService
{
    private readonly MockWorkspaceProfile _profile;

    public MockWorkspaceService()
        : this(MockWorkspaceProfiles.CreateDefault())
    {
    }

    public MockWorkspaceService(MockWorkspaceProfile profile)
    {
        _profile = profile;
    }

    public IReadOnlyList<WorkspaceNode> GetWorkspace() => _profile.WorkspaceNodes;
}
