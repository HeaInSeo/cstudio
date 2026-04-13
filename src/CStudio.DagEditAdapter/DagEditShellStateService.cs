using System;
using Avalonia;
using Avalonia.Controls.Primitives;
using CStudio.Core.Models;
using CStudio.Core.Services;
using DagEdit;
using ReactiveUI;

namespace CStudio.DagEditAdapter;

internal sealed class DagEditShellStateService : IShellStateService
{
    private readonly List<LogEntry> _logs =
    [
        new("INFO", "DagEdit shell adapter initialized", "10:10:01"),
        new("INFO", "Embedded DagEdit canvas waiting for activation", "10:10:02")
    ];

    public DagEditShellStateService(DagEditShellContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        context.ShellStateService = this;
        ActiveViewportLocation = context.ViewModel.ViewportLocation;
        ActiveViewportScale = context.ViewModel.ViewportScale;
        SelectionKind = "Canvas";
        SelectionLabel = "Canvas / None";
    }

    public event EventHandler? StateChanged;

    public Point ActiveViewportLocation { get; private set; }

    public double ActiveViewportScale { get; private set; }

    public string SelectionKind { get; private set; }

    public string SelectionLabel { get; private set; }

    public IReadOnlyList<LogEntry> Logs => _logs;

    internal void AttachInteractiveEditor(DagEditor editor, DagEditorViewModel editorViewModel)
    {
        ArgumentNullException.ThrowIfNull(editor);
        ArgumentNullException.ThrowIfNull(editorViewModel);

        ActiveViewportLocation = editorViewModel.ViewportLocation;
        ActiveViewportScale = editorViewModel.ViewportScale;
        AppendLog("INFO", "Embedded DagEdit canvas attached");

        global::System.ObservableExtensions.Subscribe(
            editorViewModel.WhenAnyValue(x => x.ViewportLocation),
            location =>
            {
                ActiveViewportLocation = location;
                AppendLog("SYNC", $"Viewport moved to {location.X:0},{location.Y:0}");
                StateChanged?.Invoke(this, EventArgs.Empty);
            });

        global::System.ObservableExtensions.Subscribe(
            editorViewModel.WhenAnyValue(x => x.ViewportScale),
            scale =>
            {
                ActiveViewportScale = scale;
                AppendLog("SYNC", $"Viewport scale changed to {scale:F2}");
                StateChanged?.Invoke(this, EventArgs.Empty);
            });

        global::System.ObservableExtensions.Subscribe(
            editor.GetObservable(SelectingItemsControl.SelectedItemProperty),
            selectedItem =>
            {
                UpdateSelection(selectedItem);
                StateChanged?.Invoke(this, EventArgs.Empty);
            });
    }

    private void UpdateSelection(object? selectedItem)
    {
        static string ShortId(Guid? id)
        {
            return id?.ToString("N")[..8] ?? "unknown";
        }

        if (selectedItem is DagItems { NodeItem: { } node })
        {
            SelectionKind = "Node";
            SelectionLabel = $"Node / {ShortId(node.NodeId)}";
            AppendLog("SELECT", $"Node selected: {ShortId(node.NodeId)}");
            return;
        }

        if (selectedItem is DagItems { ConnectionItem: { } connection })
        {
            SelectionKind = "Connection";
            SelectionLabel = $"Connection / {ShortId(connection.ConnectionId)}";
            AppendLog("SELECT", $"Connection selected: {ShortId(connection.ConnectionId)}");
            return;
        }

        SelectionKind = "Canvas";
        SelectionLabel = "Canvas / None";
        AppendLog("SELECT", "Canvas selection cleared");
    }

    private void AppendLog(string level, string message)
    {
        _logs.Add(new LogEntry(level, message, $"10:10:{_logs.Count + 1:00}"));

        if (_logs.Count > 8)
        {
            _logs.RemoveAt(0);
        }
    }
}
