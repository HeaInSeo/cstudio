using CStudio.Core.Models;
using CStudio.Core.Services;

namespace CStudio.Mock;

public sealed class MockShellChromeService : IShellChromeService
{
    public string GetWindowTitle()
    {
        return "cstudio";
    }

    public string GetSubtitle()
    {
        return "GPU-Reshape Studio inspired shell";
    }

    public string GetStatusText()
    {
        return "Sprint 02 shell contracts / mock data";
    }

    public string GetWorkspaceLabel(DocumentTab? selectedDocument)
    {
        return $"RenderLab / {selectedDocument?.Title ?? "No Document"}";
    }

    public IReadOnlyList<ShellMenuItem> GetMenus()
    {
        return
        [
            new ShellMenuItem("File"),
            new ShellMenuItem("Workspace"),
            new ShellMenuItem("Window"),
            new ShellMenuItem("Tools"),
            new ShellMenuItem("Help")
        ];
    }

    public IReadOnlyList<ShellBadge> GetActionBadges()
    {
        return
        [
            new ShellBadge("Workspace", "#7B8AA6"),
            new ShellBadge("Documents", "#8CA6D8"),
            new ShellBadge("Contract Shell", "#D7BE6A")
        ];
    }

    public IReadOnlyList<string> GetLeftStatus(DocumentTab? selectedDocument)
    {
        return
        [
            "Workspace: RenderLab",
            $"Document: {selectedDocument?.Title ?? "None"}",
            "Detached Backend"
        ];
    }

    public IReadOnlyList<ShellBadge> GetRightStatus()
    {
        return
        [
            new ShellBadge("Discovery Idle", "#6E7A90"),
            new ShellBadge("Contracts Active", "#8CA6D8"),
            new ShellBadge("Sprint 02", "#D7BE6A")
        ];
    }
}
