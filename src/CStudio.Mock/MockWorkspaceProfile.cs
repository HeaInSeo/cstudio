using CStudio.Core.Models;

namespace CStudio.Mock;

public sealed record MockWorkspaceProfile(
    string WorkspaceName,
    string Subtitle,
    string StatusText,
    string WorkspaceLabelPrefix,
    string WorkspaceSummary,
    IReadOnlyList<WorkspaceNode> WorkspaceNodes,
    IReadOnlyList<DocumentTab> Documents,
    IReadOnlyList<PropertyEntry> BaseProperties,
    IReadOnlyList<LogEntry> Logs,
    IReadOnlyList<ShellBadge> ActionBadges,
    IReadOnlyList<string> BaseLeftStatus,
    IReadOnlyList<ShellBadge> RightStatus,
    string BackendLabel,
    string ModeLabel);
