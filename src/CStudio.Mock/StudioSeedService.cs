using System.Collections.Generic;
using CStudio.Core.Models;
using CStudio.Core.Services;

namespace CStudio.Mock;

public sealed class StudioSeedService : IStudioSeedService
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

    public IReadOnlyList<DocumentTab> GetDocuments()
    {
        return
        [
            new DocumentTab(
                "Workspace Overview",
                "Mock document",
                "CStudio Sprint 00 shell.\n\nThis screen mirrors the overall information hierarchy of GPU-Reshape Studio while remaining product-neutral."),
            new DocumentTab(
                "Shader: PS_GBuffer",
                "Preview",
                "float4 PS_GBuffer() : SV_Target\n{\n    return float4(0.15, 0.34, 0.52, 1.0);\n}"),
            new DocumentTab(
                "Instrumentation Report",
                "Summary",
                "3 warnings\n1 note\n0 fatal errors\n\nNext step: connect real DagEdit-backed services.")
        ];
    }

    public IReadOnlyList<PropertyEntry> GetProperties()
    {
        return
        [
            new PropertyEntry("Session", "Mock-Session-001"),
            new PropertyEntry("Workspace", "RenderLab"),
            new PropertyEntry("Selection", "PS_GBuffer"),
            new PropertyEntry("Backend", "Detached"),
            new PropertyEntry("Theme", "Industrial Dark"),
            new PropertyEntry("Mode", "Sprint 00")
        ];
    }

    public IReadOnlyList<LogEntry> GetLogs()
    {
        return
        [
            new LogEntry("INFO", "CStudio shell initialized", "09:00:01"),
            new LogEntry("INFO", "Mock workspace loaded", "09:00:02"),
            new LogEntry("WARN", "Runtime adapter not connected", "09:00:03"),
            new LogEntry("INFO", "GPU-Reshape inspired layout active", "09:00:04")
        ];
    }
}
