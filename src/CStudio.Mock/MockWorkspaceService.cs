using CStudio.Core.Models;
using CStudio.Core.Services;

namespace CStudio.Mock;

public sealed class MockWorkspaceService : IWorkspaceService
{
    public IReadOnlyList<WorkspaceNode> GetWorkspace()
    {
        return
        [
            new WorkspaceNode("Workspace", ["Overview", "Launch Config", "Recent Sessions"]),
            new WorkspaceNode("Pipelines", ["FrameGraph/Main", "Lighting/Resolve", "Post/ToneMap"]),
            new WorkspaceNode("Shaders", ["VS_Main", "PS_GBuffer", "CS_BloomDownsample"]),
            new WorkspaceNode("Reports", ["Instrumentation", "Validation", "Messages"])
        ];
    }
}
