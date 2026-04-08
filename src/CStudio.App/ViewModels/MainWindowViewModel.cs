using System.Collections.Generic;
using System.Collections.ObjectModel;
using CStudio.Core.Models;
using CStudio.Core.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CStudio.App.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
        : this(
            new Mock.MockWorkspaceService(),
            new Mock.MockDocumentService(),
            new Mock.MockSelectionService(),
            new Mock.MockPropertyPanelService(),
            new Mock.MockLogService(),
            new Mock.MockShellChromeService())
    {
    }

    private readonly ISelectionService _selectionService;
    private readonly IPropertyPanelService _propertyPanelService;
    private readonly IShellChromeService _shellChromeService;

    public MainWindowViewModel(
        IWorkspaceService workspaceService,
        IDocumentService documentService,
        ISelectionService selectionService,
        IPropertyPanelService propertyPanelService,
        ILogService logService,
        IShellChromeService shellChromeService)
    {
        _selectionService = selectionService;
        _propertyPanelService = propertyPanelService;
        _shellChromeService = shellChromeService;

        Workspace = new ObservableCollection<WorkspaceNode>(workspaceService.GetWorkspace());
        Documents = new ObservableCollection<DocumentTab>(documentService.GetDocuments());
        Properties = [];
        Logs = new ObservableCollection<LogEntry>(logService.GetLogs());
        Menus = new ObservableCollection<ShellMenuItem>(shellChromeService.GetMenus());
        ActionBadges = new ObservableCollection<ShellBadge>(shellChromeService.GetActionBadges());
        LeftStatus = [];
        RightStatus = new ObservableCollection<ShellBadge>(shellChromeService.GetRightStatus());

        WindowTitle = shellChromeService.GetWindowTitle();
        Subtitle = shellChromeService.GetSubtitle();
        StatusText = shellChromeService.GetStatusText();

        _selectionService.SelectedDocumentChanged += HandleSelectedDocumentChanged;

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

    [ObservableProperty]
    private DocumentTab selectedDocument = null!;

    [ObservableProperty]
    private object? selectedDocumentView;

    [ObservableProperty]
    private bool showSelectedDocumentText;

    [ObservableProperty]
    private string selectedWorkspaceLabel = string.Empty;

    [RelayCommand]
    private void ActivateDocument(DocumentTab? document)
    {
        if (document is null)
        {
            return;
        }

        _selectionService.SelectDocument(document);
    }

    private void HandleSelectedDocumentChanged(DocumentTab? selectedDocument)
    {
        if (selectedDocument is null)
        {
            return;
        }

        SelectedDocument = selectedDocument;
        SelectedDocumentView = selectedDocument.ContentView;
        ShowSelectedDocumentText = selectedDocument.ContentView is null;
        SelectedWorkspaceLabel = _shellChromeService.GetWorkspaceLabel(selectedDocument);

        ReplaceContents(Properties, _propertyPanelService.GetProperties(selectedDocument));
        ReplaceContents(LeftStatus, _shellChromeService.GetLeftStatus(selectedDocument));
    }

    private static void ReplaceContents<T>(ObservableCollection<T> target, IReadOnlyList<T> items)
    {
        target.Clear();

        foreach (var item in items)
        {
            target.Add(item);
        }
    }
}
