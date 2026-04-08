using System.Collections.Generic;
using CStudio.Core.Models;

namespace CStudio.Core.Services;

public interface IWorkspaceService
{
    IReadOnlyList<WorkspaceNode> GetWorkspace();
}
