using CStudio.Core.Models;
using CStudio.Core.Services;

namespace CStudio.Mock;

public sealed class MockPropertyPanelService : IPropertyPanelService
{
    public IReadOnlyList<PropertyEntry> GetProperties(DocumentTab? selectedDocument)
    {
        var title = selectedDocument?.Title ?? "None";

        if (title.Contains("Shader"))
        {
            return
            [
                new PropertyEntry("Selection", title),
                new PropertyEntry("Document Type", "Shader"),
                new PropertyEntry("Stage", "Pixel Shader"),
                new PropertyEntry("Backend", "Detached"),
                new PropertyEntry("Theme", "Industrial Dark"),
                new PropertyEntry("Mode", "Sprint 02")
            ];
        }

        if (title.Contains("Instrumentation"))
        {
            return
            [
                new PropertyEntry("Selection", title),
                new PropertyEntry("Document Type", "Report"),
                new PropertyEntry("Warnings", "3"),
                new PropertyEntry("Notes", "1"),
                new PropertyEntry("Backend", "Detached"),
                new PropertyEntry("Mode", "Sprint 02")
            ];
        }

        return
        [
            new PropertyEntry("Session", "Mock-Session-001"),
            new PropertyEntry("Workspace", "RenderLab"),
            new PropertyEntry("Selection", title),
            new PropertyEntry("Backend", "Detached"),
            new PropertyEntry("Theme", "Industrial Dark"),
            new PropertyEntry("Mode", "Sprint 02")
        ];
    }
}
