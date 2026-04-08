namespace CStudio.Core.Services;

public sealed record ShellServiceComposition(
    IWorkspaceService WorkspaceService,
    IDocumentService DocumentService,
    ISelectionService SelectionService,
    IPropertyPanelService PropertyPanelService,
    ILogService LogService,
    IShellChromeService ShellChromeService);
