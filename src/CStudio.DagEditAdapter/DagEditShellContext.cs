using Avalonia;
using DagEdit;

namespace CStudio.DagEditAdapter;

public sealed class DagEditShellContext
{
    public DagEditShellContext(DagEditorViewModel viewModel)
    {
        ViewModel = viewModel;
    }

    public DagEditorViewModel ViewModel { get; }

    public DagEditShellStateService? ShellStateService { get; set; }

    public static DagEditShellContext CreateSample()
    {
        var vm = new DagEditorViewModel
        {
            ViewportLocation = new Point(120, 60),
            ViewportScale = 1.25
        };

        vm.ExecuteAddNode(new Point(120, 120));
        vm.ExecuteAddNode(new Point(420, 180));
        vm.ExecuteAddNode(new Point(760, 300));

        var nodeIds = vm.Dag.DAGItemsSource
            .Where(x => x.NodeItem?.NodeId != null)
            .Select(x => x.NodeItem!.NodeId!.Value)
            .ToArray();

        if (nodeIds.Length >= 2)
        {
            vm.ExecuteAddConnection(new Point(320, 182), nodeIds[0], new Point(420, 242), nodeIds[1]);
        }

        if (nodeIds.Length >= 3)
        {
            vm.ExecuteAddConnection(new Point(620, 242), nodeIds[1], new Point(760, 362), nodeIds[2]);
        }

        return new DagEditShellContext(vm);
    }
}
