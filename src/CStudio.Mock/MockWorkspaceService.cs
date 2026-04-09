using CStudio.Core.Models;
using CStudio.Core.Services;

namespace CStudio.Mock;

public sealed class MockWorkspaceService : IWorkspaceService
{
    private static readonly string[] WorkspaceItems = { "Overview", "Launch Config", "Recent Sessions" };
    private static readonly string[] PipelineItems = { "FrameGraph/Main", "Lighting/Resolve", "Post/ToneMap" };
    private static readonly string[] ShaderItems = { "VS_Main", "PS_GBuffer", "CS_BloomDownsample" };
    private static readonly string[] ReportItems = { "Instrumentation", "Validation", "Messages" };

    public IReadOnlyList<WorkspaceNode> GetWorkspace()
    {
        return
        [
            new WorkspaceNode("Workspace", WorkspaceItems),
            new WorkspaceNode("Pipelines", PipelineItems),
            new WorkspaceNode("Shaders", ShaderItems),
            new WorkspaceNode("Reports", ReportItems),
        ];
    }
}
