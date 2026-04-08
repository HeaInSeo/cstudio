using System.Collections.Generic;
using CStudio.Core.Models;

namespace CStudio.Core.Services;

public interface ILogService
{
    IReadOnlyList<LogEntry> GetLogs();
}
