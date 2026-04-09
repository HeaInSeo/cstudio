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
        return "DagEdit interactive shell sync over GPU-Reshape inspired shell";
    }

    public string GetStatusText()
    {
        return "Sprint 05 interactive shell sync / live embedded DagEdit";
    }

    public string GetWorkspaceLabel(DocumentTab? selectedDocument)
    {
        var selectionLabel = _context.ShellStateService?.SelectionLabel ?? "Canvas / None";
        return $"DagEdit Sample / {selectedDocument?.Title ?? "No Document"} / {selectionLabel}";
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
        var shellState = _context.ShellStateService;
        var viewport = shellState?.ActiveViewportLocation ?? vm.ViewportLocation;
        return
        [
            $"DagEdit Nodes: {vm.NodeCount}",
            $"DagEdit Connections: {vm.ConnectionCount}",
            $"Document: {selectedDocument?.Title ?? "None"}",
            $"Selection: {shellState?.SelectionKind ?? "Canvas"}",
            $"Viewport: {viewport.X:0},{viewport.Y:0}"
        ];
    }

    public IReadOnlyList<ShellBadge> GetRightStatus()
    {
        var shellState = _context.ShellStateService;
        var scale = shellState?.ActiveViewportScale ?? _context.ViewModel.ViewportScale;

        return
        [
            new ShellBadge("DagEdit Live Sample", "#8FD3A9"),
            new ShellBadge($"Scale {scale:F2}", "#8CA6D8"),
            new ShellBadge(shellState?.SelectionKind ?? "Canvas", "#D7BE6A"),
        ];
    }
}
