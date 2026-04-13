using System.Globalization;
using CStudio.Core.Models;
using CStudio.Core.Services;

namespace CStudio.DagEditAdapter;

internal sealed class DagEditPropertyPanelService : IPropertyPanelService
{
    private readonly DagEditShellContext _context;

    public DagEditPropertyPanelService(DagEditShellContext context)
    {
        _context = context;
    }

    public IReadOnlyList<PropertyEntry> GetProperties(DocumentTab? selectedDocument)
    {
        var vm = _context.ViewModel;
        var shellState = _context.ShellStateService;

        return
        [
            new PropertyEntry("Document", selectedDocument?.Title ?? "None"),
            new PropertyEntry("Source", "DagEdit Adapter"),
            new PropertyEntry("Node Count", vm.NodeCount.ToString(CultureInfo.InvariantCulture)),
            new PropertyEntry("Connection Count", vm.ConnectionCount.ToString(CultureInfo.InvariantCulture)),
            new PropertyEntry("Viewport Location", (shellState?.ActiveViewportLocation ?? vm.ViewportLocation).ToString()),
            new PropertyEntry("Viewport Scale", (shellState?.ActiveViewportScale ?? vm.ViewportScale).ToString("F2", CultureInfo.InvariantCulture)),
            new PropertyEntry("Selection Kind", shellState?.SelectionKind ?? "Canvas"),
            new PropertyEntry("Selection Label", shellState?.SelectionLabel ?? "Canvas / None")
        ];
    }
}
