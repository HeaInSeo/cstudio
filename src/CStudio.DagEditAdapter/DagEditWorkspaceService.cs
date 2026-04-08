using CStudio.Core.Models;
using CStudio.Core.Services;

namespace CStudio.DagEditAdapter;

public sealed class DagEditWorkspaceService : IWorkspaceService
{
    private readonly DagEditShellContext _context;

    public DagEditWorkspaceService(DagEditShellContext context)
    {
        _context = context;
    }

    public IReadOnlyList<WorkspaceNode> GetWorkspace()
    {
        var vm = _context.ViewModel;
        var nodes = vm.Dag.DAGItemsSource
            .Where(x => x.NodeItem?.NodeId != null)
            .Select(x => x.NodeItem!)
            .Take(3)
            .Select(x => $"{x.NodeId} @ {x.Location}")
            .ToArray();

        return
        [
            new WorkspaceNode("DagEdit Workspace", ["Graph Sample", "Adapter Path", "Shell Mapping"]),
            new WorkspaceNode("Graph Metrics", [$"Nodes: {vm.NodeCount}", $"Connections: {vm.ConnectionCount}", $"Scale: {vm.ViewportScale:F2}"]),
            new WorkspaceNode("Visible Nodes", nodes),
            new WorkspaceNode("Documents", ["Dag Graph Overview", "Viewport State", "Connection Snapshot"])
        ];
    }
}
