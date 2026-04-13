using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CStudio.Core.Models;
using CStudio.Core.Services;

namespace CStudio.App.ViewModels;

internal sealed partial class MainWindowViewModel : ViewModelBase
{
    private readonly IReadOnlyList<WorkspaceShellDefinition> _workspaceDefinitions;
    private ISelectionService _selectionService = null!;
    private IShellStateService _shellStateService = null!;
    private IPropertyPanelService _propertyPanelService = null!;
    private ILogService _logService = null!;
    private IShellChromeService _shellChromeService = null!;
    private int _activeWorkspaceIndex;

    [ObservableProperty]
    private DocumentTab selectedDocument = null!;

    [ObservableProperty]
    private object? selectedDocumentView;

    [ObservableProperty]
    private bool showSelectedDocumentText;

    [ObservableProperty]
    private string selectedWorkspaceLabel = string.Empty;

    [ObservableProperty]
    private RoleWorkspaceDescriptor activeWorkspace = null!;

    [ObservableProperty]
    private string workspaceSummary = string.Empty;

    [ObservableProperty]
    private string workspacePosition = string.Empty;

    public MainWindowViewModel()
        : this(SampleWorkspaceCatalog.Create())
    {
    }

    public MainWindowViewModel(IReadOnlyList<WorkspaceShellDefinition> workspaceDefinitions)
    {
        ArgumentNullException.ThrowIfNull(workspaceDefinitions);

        if (workspaceDefinitions.Count == 0)
        {
            throw new ArgumentException("At least one workspace definition is required.", nameof(workspaceDefinitions));
        }

        _workspaceDefinitions = workspaceDefinitions;

        WorkspaceOptions = new ObservableCollection<RoleWorkspaceDescriptor>(workspaceDefinitions.Select(x => x.Workspace));
        Menus = new ObservableCollection<ShellMenuItem>();
        ActionBadges = new ObservableCollection<ShellBadge>();
        Workspace = new ObservableCollection<WorkspaceNode>();
        Documents = new ObservableCollection<DocumentTab>();
        Properties = new ObservableCollection<PropertyEntry>();
        Logs = new ObservableCollection<LogEntry>();
        LeftStatus = new ObservableCollection<string>();
        RightStatus = new ObservableCollection<ShellBadge>();

        SwitchWorkspace(0);
    }

    public ObservableCollection<RoleWorkspaceDescriptor> WorkspaceOptions { get; }

    public string WindowTitle => _shellChromeService.GetWindowTitle();

    public string Subtitle => _shellChromeService.GetSubtitle();

    public string StatusText => _shellChromeService.GetStatusText();

    public ObservableCollection<ShellMenuItem> Menus { get; }

    public ObservableCollection<ShellBadge> ActionBadges { get; }

    public ObservableCollection<WorkspaceNode> Workspace { get; }

    public ObservableCollection<DocumentTab> Documents { get; }

    public ObservableCollection<PropertyEntry> Properties { get; }

    public ObservableCollection<LogEntry> Logs { get; }

    public ObservableCollection<string> LeftStatus { get; }

    public ObservableCollection<ShellBadge> RightStatus { get; }

    public bool CanSwitchWorkspaces => _workspaceDefinitions.Count > 1;

    private static void ReplaceContents<T>(ObservableCollection<T> target, IReadOnlyList<T> items)
    {
        target.Clear();

        foreach (var item in items)
        {
            target.Add(item);
        }
    }

    private static int NormalizeIndex(int index, int count)
    {
        var normalized = index % count;
        return normalized < 0 ? normalized + count : normalized;
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

    [RelayCommand(CanExecute = nameof(CanSwitchWorkspaces))]
    private void PreviousWorkspace()
    {
        SwitchWorkspace(_activeWorkspaceIndex - 1);
    }

    [RelayCommand(CanExecute = nameof(CanSwitchWorkspaces))]
    private void NextWorkspace()
    {
        SwitchWorkspace(_activeWorkspaceIndex + 1);
    }

    [RelayCommand]
    private void SelectWorkspace(RoleWorkspaceDescriptor? workspace)
    {
        if (workspace is null)
        {
            return;
        }

        var index = _workspaceDefinitions
            .Select((definition, position) => new { definition.Workspace.Kind, position })
            .FirstOrDefault(x => x.Kind == workspace.Kind)?.position ?? -1;

        if (index >= 0)
        {
            SwitchWorkspace(index);
        }
    }

    private void HandleSelectedDocumentChanged(object? sender, SelectedDocumentChangedEventArgs e)
    {
        ArgumentNullException.ThrowIfNull(e);

        var document = e.SelectedDocument;

        if (document is null)
        {
            return;
        }

        SelectedDocument = document;
        SelectedDocumentView = document.ContentView;
        ShowSelectedDocumentText = document.ContentView is null;
        SelectedWorkspaceLabel = _shellChromeService.GetWorkspaceLabel(document);

        ReplaceContents(Properties, _propertyPanelService.GetProperties(document));
        ReplaceContents(Logs, _logService.GetLogs());
        ReplaceContents(LeftStatus, _shellChromeService.GetLeftStatus(document));
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

    private void SwitchWorkspace(int requestedIndex)
    {
        if (_selectionService is not null)
        {
            _selectionService.SelectedDocumentChanged -= HandleSelectedDocumentChanged;
        }

        if (_shellStateService is not null)
        {
            _shellStateService.StateChanged -= HandleShellStateChanged;
        }

        _activeWorkspaceIndex = NormalizeIndex(requestedIndex, _workspaceDefinitions.Count);

        var definition = _workspaceDefinitions[_activeWorkspaceIndex];
        ActiveWorkspace = definition.Workspace;
        WorkspaceSummary = definition.Workspace.Summary;
        WorkspacePosition = $"{_activeWorkspaceIndex + 1} / {_workspaceDefinitions.Count}";

        _selectionService = definition.Composition.SelectionService;
        _shellStateService = definition.Composition.ShellStateService;
        _propertyPanelService = definition.Composition.PropertyPanelService;
        _logService = definition.Composition.LogService;
        _shellChromeService = definition.Composition.ShellChromeService;

        ReplaceContents(Menus, _shellChromeService.GetMenus());
        ReplaceContents(ActionBadges, _shellChromeService.GetActionBadges());
        ReplaceContents(Workspace, definition.Composition.WorkspaceService.GetWorkspace());
        ReplaceContents(Documents, definition.Composition.DocumentService.GetDocuments());
        ReplaceContents(Logs, _logService.GetLogs());
        ReplaceContents(LeftStatus, Array.Empty<string>());
        ReplaceContents(RightStatus, _shellChromeService.GetRightStatus());

        OnPropertyChanged(nameof(WindowTitle));
        OnPropertyChanged(nameof(Subtitle));
        OnPropertyChanged(nameof(StatusText));
        OnPropertyChanged(nameof(CanSwitchWorkspaces));
        PreviousWorkspaceCommand.NotifyCanExecuteChanged();
        NextWorkspaceCommand.NotifyCanExecuteChanged();

        _selectionService.SelectedDocumentChanged += HandleSelectedDocumentChanged;
        _shellStateService.StateChanged += HandleShellStateChanged;

        if (Documents.Count > 0)
        {
            _selectionService.SelectDocument(Documents[0]);
            return;
        }

        SelectedWorkspaceLabel = ActiveWorkspace.Title;
        SelectedDocument = new DocumentTab("No Document", ActiveWorkspace.Title, WorkspaceSummary);
        SelectedDocumentView = null;
        ShowSelectedDocumentText = true;
        ReplaceContents(Properties, Array.Empty<PropertyEntry>());
    }
}
