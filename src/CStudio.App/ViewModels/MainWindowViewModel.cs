using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CStudio.Core.Models;
using CStudio.Core.Services;
using CStudio.Mock;

namespace CStudio.App.ViewModels;

internal sealed partial class MainWindowViewModel : ViewModelBase
{
    private readonly ISelectionService _selectionService;
    private readonly IShellStateService _shellStateService;
    private readonly IPropertyPanelService _propertyPanelService;
    private readonly ILogService _logService;
    private readonly IShellChromeService _shellChromeService;

    [ObservableProperty]
    private DocumentTab selectedDocument = null!;

    [ObservableProperty]
    private object? selectedDocumentView;

    [ObservableProperty]
    private bool showSelectedDocumentText;

    [ObservableProperty]
    private string selectedWorkspaceLabel = string.Empty;

    public MainWindowViewModel()
        : this(
            new MockWorkspaceService(),
            new MockDocumentService(),
            new MockSelectionService(),
            new MockShellStateService(),
            new MockPropertyPanelService(),
            new MockLogService(),
            new MockShellChromeService())
    {
    }

    public MainWindowViewModel(
        IWorkspaceService workspaceService,
        IDocumentService documentService,
        ISelectionService selectionService,
        IShellStateService shellStateService,
        IPropertyPanelService propertyPanelService,
        ILogService logService,
        IShellChromeService shellChromeService)
    {
        ArgumentNullException.ThrowIfNull(workspaceService);
        ArgumentNullException.ThrowIfNull(documentService);
        ArgumentNullException.ThrowIfNull(selectionService);
        ArgumentNullException.ThrowIfNull(shellStateService);
        ArgumentNullException.ThrowIfNull(propertyPanelService);
        ArgumentNullException.ThrowIfNull(logService);
        ArgumentNullException.ThrowIfNull(shellChromeService);

        _selectionService = selectionService;
        _shellStateService = shellStateService;
        _propertyPanelService = propertyPanelService;
        _logService = logService;
        _shellChromeService = shellChromeService;

        Workspace = new ObservableCollection<WorkspaceNode>(workspaceService.GetWorkspace());
        Documents = new ObservableCollection<DocumentTab>(documentService.GetDocuments());
        Properties = new ObservableCollection<PropertyEntry>();
        Logs = new ObservableCollection<LogEntry>(logService.GetLogs());
        Menus = new ObservableCollection<ShellMenuItem>(shellChromeService.GetMenus());
        ActionBadges = new ObservableCollection<ShellBadge>(shellChromeService.GetActionBadges());
        LeftStatus = new ObservableCollection<string>();
        RightStatus = new ObservableCollection<ShellBadge>(shellChromeService.GetRightStatus());

        WindowTitle = shellChromeService.GetWindowTitle();
        Subtitle = shellChromeService.GetSubtitle();
        StatusText = shellChromeService.GetStatusText();

        _selectionService.SelectedDocumentChanged += HandleSelectedDocumentChanged;
        _shellStateService.StateChanged += HandleShellStateChanged;

        if (Documents.Count > 0)
        {
            _selectionService.SelectDocument(Documents[0]);
        }
    }

    public string WindowTitle { get; }

    public string Subtitle { get; }

    public string StatusText { get; }

    public ObservableCollection<ShellMenuItem> Menus { get; }

    public ObservableCollection<ShellBadge> ActionBadges { get; }

    public ObservableCollection<WorkspaceNode> Workspace { get; }

    public ObservableCollection<DocumentTab> Documents { get; }

    public ObservableCollection<PropertyEntry> Properties { get; }

    public ObservableCollection<LogEntry> Logs { get; }

    public ObservableCollection<string> LeftStatus { get; }

    public ObservableCollection<ShellBadge> RightStatus { get; }

    private static void ReplaceContents<T>(ObservableCollection<T> target, IReadOnlyList<T> items)
    {
        target.Clear();

        foreach (var item in items)
        {
            target.Add(item);
        }
    }

    [RelayCommand]
    private void ActivateDocument(DocumentTab? document)
    {
        if (document is null)
        {
            return;
        }

        _selectionService.SelectDocument(document);
    }

    private void HandleSelectedDocumentChanged(object? sender, SelectedDocumentChangedEventArgs e)
    {
        ArgumentNullException.ThrowIfNull(e);

        var selectedDocument = e.SelectedDocument;

        if (selectedDocument is null)
        {
            return;
        }

        SelectedDocument = selectedDocument;
        SelectedDocumentView = selectedDocument.ContentView;
        ShowSelectedDocumentText = selectedDocument.ContentView is null;
        SelectedWorkspaceLabel = _shellChromeService.GetWorkspaceLabel(selectedDocument);

        ReplaceContents(Properties, _propertyPanelService.GetProperties(selectedDocument));
        ReplaceContents(Logs, _logService.GetLogs());
        ReplaceContents(LeftStatus, _shellChromeService.GetLeftStatus(selectedDocument));
        ReplaceContents(RightStatus, _shellChromeService.GetRightStatus());
    }

    private void HandleShellStateChanged(object? sender, EventArgs e)
    {
        if (SelectedDocument is null)
        {
            return;
        }

        ReplaceContents(Properties, _propertyPanelService.GetProperties(SelectedDocument));
        ReplaceContents(Logs, _logService.GetLogs());
        ReplaceContents(LeftStatus, _shellChromeService.GetLeftStatus(SelectedDocument));
        ReplaceContents(RightStatus, _shellChromeService.GetRightStatus());
        SelectedWorkspaceLabel = _shellChromeService.GetWorkspaceLabel(SelectedDocument);
    }
}
