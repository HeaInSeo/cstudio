using System.Collections.ObjectModel;
using CStudio.Core.Models;
using CStudio.Mock;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CStudio.App.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        var seedService = new StudioSeedService();

        Workspace = new ObservableCollection<WorkspaceNode>(seedService.GetWorkspace());
        Documents = new ObservableCollection<DocumentTab>(seedService.GetDocuments());
        Properties = new ObservableCollection<PropertyEntry>(seedService.GetProperties());
        Logs = new ObservableCollection<LogEntry>(seedService.GetLogs());
        Menus = new ObservableCollection<ShellMenuItem>
        {
            new("File"),
            new("Workspace"),
            new("Window"),
            new("Tools"),
            new("Help")
        };

        LeftStatus = new ObservableCollection<string>
        {
            "Workspace: RenderLab",
            "Mock Session",
            "Detached Backend"
        };

        RightStatus = new ObservableCollection<ShellBadge>
        {
            new("Discovery Idle", "#6E7A90"),
            new("Bus Mode", "#8CA6D8"),
            new("Sprint 01", "#D7BE6A")
        };

        ActionBadges = new ObservableCollection<ShellBadge>
        {
            new("Workspace", "#7B8AA6"),
            new("Documents", "#8CA6D8"),
            new("Mock Runtime", "#D7BE6A")
        };

        SelectedDocument = Documents[0];
        SelectedWorkspaceLabel = "RenderLab / Workspace Overview";
        WindowTitle = "cstudio";
        Subtitle = "GPU-Reshape Studio inspired shell";
        StatusText = "Sprint 01 shell parity / mock data";
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
    private DocumentTab selectedDocument;

    [ObservableProperty]
    private string selectedWorkspaceLabel;

    [RelayCommand]
    private void ActivateDocument(DocumentTab? document)
    {
        if (document is null)
        {
            return;
        }

        SelectedDocument = document;
    }
}
