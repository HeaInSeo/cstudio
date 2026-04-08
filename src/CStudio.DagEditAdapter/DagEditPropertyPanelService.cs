using CStudio.Core.Models;
using CStudio.Core.Services;

namespace CStudio.DagEditAdapter;

public sealed class DagEditPropertyPanelService : IPropertyPanelService
{
    private readonly DagEditShellContext _context;

    public DagEditPropertyPanelService(DagEditShellContext context)
    {
        _context = context;
    }

    public IReadOnlyList<PropertyEntry> GetProperties(DocumentTab? selectedDocument)
    {
        var vm = _context.ViewModel;

        return
        [
            new PropertyEntry("Document", selectedDocument?.Title ?? "None"),
            new PropertyEntry("Source", "DagEdit Adapter"),
            new PropertyEntry("Node Count", vm.NodeCount.ToString()),
            new PropertyEntry("Connection Count", vm.ConnectionCount.ToString()),
            new PropertyEntry("Viewport Location", vm.ViewportLocation.ToString()),
            new PropertyEntry("Viewport Scale", vm.ViewportScale.ToString("F2"))
        ];
    }
}
