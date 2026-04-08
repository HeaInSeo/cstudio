using System.Collections.ObjectModel;
using CStudio.Core.Models;
using CStudio.Mock;

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

        SelectedDocument = Documents[0];
        WindowTitle = "cstudio";
        Subtitle = "GPU-Reshape Studio inspired shell";
        StatusText = "Sprint 00 foundation / mock data";
    }

    public string WindowTitle { get; }

    public string Subtitle { get; }

    public string StatusText { get; }

    public ObservableCollection<WorkspaceNode> Workspace { get; }

    public ObservableCollection<DocumentTab> Documents { get; }

    public ObservableCollection<PropertyEntry> Properties { get; }

    public ObservableCollection<LogEntry> Logs { get; }

    public DocumentTab SelectedDocument { get; }
}
