namespace CStudio.Core.Services;

public sealed record ShellServiceComposition(
    IWorkspaceService WorkspaceService,
    IDocumentService DocumentService,
    ISelectionService SelectionService,
    IShellStateService ShellStateService,
    IPropertyPanelService PropertyPanelService,
    ILogService LogService,
    IShellChromeService ShellChromeService);
