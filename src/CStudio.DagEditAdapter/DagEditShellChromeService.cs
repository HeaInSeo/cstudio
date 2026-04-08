using CStudio.Core.Models;
using CStudio.Core.Services;

namespace CStudio.DagEditAdapter;

public sealed class DagEditShellChromeService : IShellChromeService
{
    private readonly DagEditShellContext _context;

    public DagEditShellChromeService(DagEditShellContext context)
    {
        _context = context;
    }

    public string GetWindowTitle()
    {
        return "cstudio";
    }

    public string GetSubtitle()
    {
        return "DagEdit adapter pass over GPU-Reshape inspired shell";
    }

    public string GetStatusText()
    {
        return "Sprint 03 DagEdit adapter / live sample state";
    }

    public string GetWorkspaceLabel(DocumentTab? selectedDocument)
    {
        return $"DagEdit Sample / {selectedDocument?.Title ?? "No Document"}";
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
            new ShellBadge("DagEdit Adapter", "#8FD3A9")
        ];
    }

    public IReadOnlyList<string> GetLeftStatus(DocumentTab? selectedDocument)
    {
        var vm = _context.ViewModel;
        return
        [
            $"DagEdit Nodes: {vm.NodeCount}",
            $"DagEdit Connections: {vm.ConnectionCount}",
            $"Document: {selectedDocument?.Title ?? "None"}"
        ];
    }

    public IReadOnlyList<ShellBadge> GetRightStatus()
    {
        return
        [
            new ShellBadge("DagEdit Live Sample", "#8FD3A9"),
            new ShellBadge("Viewport Sync", "#8CA6D8"),
            new ShellBadge("Sprint 03", "#D7BE6A")
        ];
    }
}
