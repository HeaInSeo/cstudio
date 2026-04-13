using CStudio.Core.Services;

namespace CStudio.Mock;

public static class MockShellFactory
{
    public static ShellServiceComposition Create(MockWorkspaceProfile profile)
    {
        ArgumentNullException.ThrowIfNull(profile);

        return new ShellServiceComposition(
            new MockWorkspaceService(profile),
            new MockDocumentService(profile),
            new MockSelectionService(),
            new MockShellStateService(),
            new MockPropertyPanelService(profile),
            new MockLogService(profile),
            new MockShellChromeService(profile));
    }
}
