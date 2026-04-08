using CStudio.Core.Models;
using CStudio.Core.Services;

namespace CStudio.DagEditAdapter;

public sealed class DagEditLogService : ILogService
{
    private readonly DagEditShellContext _context;

    public DagEditLogService(DagEditShellContext context)
    {
        _context = context;
    }

    public IReadOnlyList<LogEntry> GetLogs()
    {
        var vm = _context.ViewModel;

        return
        [
            new LogEntry("INFO", "DagEdit shell adapter initialized", "10:10:01"),
            new LogEntry("INFO", $"DagEdit nodes mapped: {vm.NodeCount}", "10:10:02"),
            new LogEntry("INFO", $"DagEdit connections mapped: {vm.ConnectionCount}", "10:10:03"),
            new LogEntry("INFO", $"Viewport scale: {vm.ViewportScale:F2}", "10:10:04"),
            new LogEntry("INFO", "CStudio now composes shell state from a DagEdit-backed adapter path", "10:10:05")
        ];
    }
}
