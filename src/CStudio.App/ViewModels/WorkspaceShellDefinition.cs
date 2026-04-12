using CStudio.Core.Models;
using CStudio.Core.Services;

namespace CStudio.App.ViewModels;

internal sealed record WorkspaceShellDefinition(
    RoleWorkspaceDescriptor Workspace,
    ShellServiceComposition Composition);
