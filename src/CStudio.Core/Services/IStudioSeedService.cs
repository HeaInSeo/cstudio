using System.Collections.Generic;
using CStudio.Core.Models;

namespace CStudio.Core.Services;

public interface IStudioSeedService
{
    IReadOnlyList<WorkspaceNode> GetWorkspace();

    IReadOnlyList<DocumentTab> GetDocuments();

    IReadOnlyList<PropertyEntry> GetProperties();

    IReadOnlyList<LogEntry> GetLogs();
}
