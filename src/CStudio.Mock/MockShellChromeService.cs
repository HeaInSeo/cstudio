using CStudio.Core.Models;
using CStudio.Core.Services;

namespace CStudio.Mock;

public sealed class MockShellChromeService : IShellChromeService
{
    private readonly MockWorkspaceProfile _profile;

    public MockShellChromeService()
        : this(MockWorkspaceProfiles.CreateDefault())
    {
    }

    public MockShellChromeService(MockWorkspaceProfile profile)
    {
        _profile = profile;
    }

    public string GetWindowTitle()
    {
        return "cstudio";
    }

    public string GetSubtitle()
    {
        return _profile.Subtitle;
    }

    public string GetStatusText()
    {
        return _profile.StatusText;
    }

    public string GetWorkspaceLabel(DocumentTab? selectedDocument)
    {
        return $"{_profile.WorkspaceLabelPrefix} / {selectedDocument?.Title ?? "No Document"}";
    }

    public IReadOnlyList<ShellMenuItem> GetMenus()
    {
        return
        [
            new ShellMenuItem("File"),
            new ShellMenuItem("Workspace"),
            new ShellMenuItem("Window"),
            new ShellMenuItem("Tools"),
            new ShellMenuItem("Help")
        ];
    }

    public IReadOnlyList<ShellBadge> GetActionBadges()
    {
        return _profile.ActionBadges;
    }

    public IReadOnlyList<string> GetLeftStatus(DocumentTab? selectedDocument)
    {
        return _profile.BaseLeftStatus
            .Concat([$"Document: {selectedDocument?.Title ?? "None"}"])
            .ToArray();
    }

    public IReadOnlyList<ShellBadge> GetRightStatus()
    {
        return _profile.RightStatus;
    }
}
