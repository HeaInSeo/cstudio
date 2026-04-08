using CStudio.Core.Services;

namespace CStudio.DagEditAdapter;

public static class DagEditShellFactory
{
    public static ShellServiceComposition CreateSample()
    {
        var context = DagEditShellContext.CreateSample();
        var shellStateService = new DagEditShellStateService(context);

        return new ShellServiceComposition(
            new DagEditWorkspaceService(context),
            new DagEditDocumentService(context),
            new DagEditSelectionService(),
            shellStateService,
            new DagEditPropertyPanelService(context),
            new DagEditLogService(context),
            new DagEditShellChromeService(context));
    }
}
