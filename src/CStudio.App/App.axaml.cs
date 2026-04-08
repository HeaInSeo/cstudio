using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using CStudio.App.ViewModels;
using CStudio.App.Views;
using CStudio.Core.Services;
using CStudio.DagEditAdapter;

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
            ShellServiceComposition composition = DagEditShellFactory.CreateSample();

            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(
                    composition.WorkspaceService,
                    composition.DocumentService,
                    composition.SelectionService,
                    composition.ShellStateService,
                    composition.PropertyPanelService,
                    composition.LogService,
                    composition.ShellChromeService),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
