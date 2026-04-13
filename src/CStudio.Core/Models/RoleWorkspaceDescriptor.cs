namespace CStudio.Core.Models;

public sealed record RoleWorkspaceDescriptor(
    RoleWorkspaceKind Kind,
    string Title,
    string ShortTitle,
    string Accent,
    string Summary);
