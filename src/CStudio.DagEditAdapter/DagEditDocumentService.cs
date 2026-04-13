using System.Globalization;
using System.Text;
using CStudio.Core.Models;
using CStudio.Core.Services;

namespace CStudio.DagEditAdapter;

internal sealed class DagEditDocumentService : IDocumentService
{
    private readonly DagEditShellContext _context;

    public DagEditDocumentService(DagEditShellContext context)
    {
        _context = context;
    }

    public IReadOnlyList<DocumentTab> GetDocuments()
    {
        var vm = _context.ViewModel;
        var nodes = vm.Dag.DAGItemsSource.Where(x => x.NodeItem != null).Select(x => x.NodeItem!).ToArray();
        var connections = vm.Dag.DAGItemsSource.Where(x => x.ConnectionItem != null).Select(x => x.ConnectionItem!).ToArray();

        var graphSummary = new StringBuilder()
            .AppendLine("DagEdit sample graph snapshot")
            .AppendLine()
            .AppendLine(FormattableString.Invariant($"NodeCount: {vm.NodeCount}"))
            .AppendLine(FormattableString.Invariant($"ConnectionCount: {vm.ConnectionCount}"))
            .AppendLine(FormattableString.Invariant($"ViewportLocation: {vm.ViewportLocation}"))
            .AppendLine(FormattableString.Invariant($"ViewportScale: {vm.ViewportScale}"))
            .AppendLine()
            .AppendLine("Nodes:")
            .AppendJoin(Environment.NewLine, nodes.Select((n, index) => FormattableString.Invariant($"  {index + 1}. {n.NodeId} @ {n.Location}")))
            .ToString();

        var viewportSummary = new StringBuilder()
            .AppendLine("DagEdit viewport state")
            .AppendLine()
            .AppendLine(FormattableString.Invariant($"Location: {vm.ViewportLocation}"))
            .AppendLine(FormattableString.Invariant($"Scale: {vm.ViewportScale}"))
            .AppendLine()
            .AppendLine("This document is sourced from a real DagEdit.DagEditorViewModel instance through the adapter layer.")
            .ToString();

        var connectionSummary = new StringBuilder()
            .AppendLine("DagEdit connection snapshot")
            .AppendLine()
            .AppendJoin(Environment.NewLine, connections.Select((c, index) =>
                FormattableString.Invariant($"  {index + 1}. {c.ConnectionId} : {c.SourceNodeId} -> {c.TargetNodeId}")))
            .ToString();

        return
        [
            new DocumentTab("Dag Canvas", "Embedded DagEdit editor", "Live DagEdit canvas embedded in the cstudio shell.", new DagEditDocumentView(_context)),
            new DocumentTab("Dag Graph Overview", "DagEdit adapter", graphSummary),
            new DocumentTab("Viewport State", "DagEdit adapter", viewportSummary),
            new DocumentTab("Connection Snapshot", "DagEdit adapter", connectionSummary)
        ];
    }
}
