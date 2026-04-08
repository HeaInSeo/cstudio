using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using CStudio.App.ViewModels;
using CStudio.App.Views;
using CStudio.Core.Services;
using CStudio.Mock;

namespace CStudio.App;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            IWorkspaceService workspaceService = new MockWorkspaceService();
            IDocumentService documentService = new MockDocumentService();
            ISelectionService selectionService = new MockSelectionService();
            IPropertyPanelService propertyPanelService = new MockPropertyPanelService();
            ILogService logService = new MockLogService();
            IShellChromeService shellChromeService = new MockShellChromeService();

            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(
                    workspaceService,
                    documentService,
                    selectionService,
                    propertyPanelService,
                    logService,
                    shellChromeService),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
