using CStudio.Core.Services;

namespace CStudio.DagEditAdapter;

public static class DagEditShellFactory
{
    public static ShellServiceComposition CreateSample()
    {
        var context = DagEditShellContext.CreateSample();

        return new ShellServiceComposition(
            new DagEditWorkspaceService(context),
            new DagEditDocumentService(context),
            new DagEditSelectionService(),
            new DagEditPropertyPanelService(context),
            new DagEditLogService(context),
            new DagEditShellChromeService(context));
    }
}
