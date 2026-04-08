using System.Collections.Generic;
using CStudio.Core.Models;

namespace CStudio.Core.Services;

public interface IShellChromeService
{
    string GetWindowTitle();

    string GetSubtitle();

    string GetStatusText();

    string GetWorkspaceLabel(DocumentTab? selectedDocument);

    IReadOnlyList<ShellMenuItem> GetMenus();

    IReadOnlyList<ShellBadge> GetActionBadges();

    IReadOnlyList<string> GetLeftStatus(DocumentTab? selectedDocument);

    IReadOnlyList<ShellBadge> GetRightStatus();
}
