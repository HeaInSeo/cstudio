using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;
using DagEdit;

namespace CStudio.DagEditAdapter;

public sealed class DagEditDocumentView : Grid
{
    public DagEditDocumentView(DagEditShellContext context)
    {
        RowDefinitions = new RowDefinitions("Auto,*");

        var sourceViewModel = context.ViewModel;
        var editor = new DagEditor();
        var editorViewModel = (DagEditorViewModel)editor.DataContext!;

        editorViewModel.ViewportLocation = sourceViewModel.ViewportLocation;
        editorViewModel.ViewportScale = sourceViewModel.ViewportScale;

        foreach (var node in sourceViewModel.Dag.DAGItemsSource.Where(x => x.NodeItem != null).Select(x => x.NodeItem!))
        {
            editorViewModel.ExecuteAddNode(node.Location);
        }

        var sourceNodes = sourceViewModel.Dag.DAGItemsSource.Where(x => x.NodeItem != null).Select(x => x.NodeItem!).ToArray();
        var targetNodeIds = editorViewModel.Dag.DAGItemsSource
            .Where(x => x.NodeItem?.NodeId != null)
            .Select(x => x.NodeItem!.NodeId!.Value)
            .ToArray();

        var nodeIdMap = sourceNodes
            .Zip(targetNodeIds, (sourceNode, targetNodeId) => new { sourceNode.NodeId, targetNodeId })
            .Where(x => x.NodeId.HasValue)
            .ToDictionary(x => x.NodeId!.Value, x => x.targetNodeId);

        foreach (var connection in sourceViewModel.Dag.DAGItemsSource.Where(x => x.ConnectionItem != null).Select(x => x.ConnectionItem!))
        {
            if (connection.SourceNodeId is null || connection.TargetNodeId is null)
            {
                continue;
            }

            if (!nodeIdMap.TryGetValue(connection.SourceNodeId.Value, out var mappedSourceNodeId) ||
                !nodeIdMap.TryGetValue(connection.TargetNodeId.Value, out var mappedTargetNodeId))
            {
                continue;
            }

            editorViewModel.ExecuteAddConnection(
                connection.SourceAnchor,
                mappedSourceNodeId,
                connection.TargetAnchor,
                mappedTargetNodeId);
        }

        var titleBlock = new TextBlock
        {
            Text = "DagEdit Canvas",
            Foreground = new SolidColorBrush(Color.Parse("#F4F7FB")),
            FontWeight = FontWeight.SemiBold,
            VerticalAlignment = VerticalAlignment.Center
        };

        var statsBadge = new Border
        {
            Background = new SolidColorBrush(Color.Parse("#1C2433")),
            BorderBrush = new SolidColorBrush(Color.Parse("#37445C")),
            BorderThickness = new Thickness(1),
            CornerRadius = new CornerRadius(6),
            Padding = new Thickness(8, 4),
            Child = new TextBlock
            {
                Text = $"{editorViewModel.NodeCount} nodes / {editorViewModel.ConnectionCount} links",
                Foreground = new SolidColorBrush(Color.Parse("#9EB3D6")),
                FontSize = 12
            }
        };
        Grid.SetColumn(statsBadge, 1);

        var chromeGrid = new Grid
        {
            ColumnDefinitions = new ColumnDefinitions("*,Auto")
        };
        chromeGrid.Children.Add(titleBlock);
        chromeGrid.Children.Add(statsBadge);

        var chrome = new Border
        {
            Background = new SolidColorBrush(Color.Parse("#111722")),
            BorderBrush = new SolidColorBrush(Color.Parse("#252D3E")),
            BorderThickness = new Thickness(0, 0, 0, 1),
            Padding = new Thickness(12, 10),
            Child = chromeGrid
        };

        var host = new Border
        {
            Background = new SolidColorBrush(Color.Parse("#0E131D")),
            Padding = new Thickness(12),
            Child = editor
        };

        Children.Add(chrome);
        Children.Add(host);
        SetRow(host, 1);
    }
}
