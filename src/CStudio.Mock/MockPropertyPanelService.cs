using System;
using CStudio.Core.Models;
using CStudio.Core.Services;

namespace CStudio.Mock;

public sealed class MockPropertyPanelService : IPropertyPanelService
{
    private readonly MockWorkspaceProfile _profile;

    public MockPropertyPanelService()
        : this(MockWorkspaceProfiles.CreateDefault())
    {
    }

    public MockPropertyPanelService(MockWorkspaceProfile profile)
    {
        _profile = profile;
    }

    public IReadOnlyList<PropertyEntry> GetProperties(DocumentTab? selectedDocument)
    {
        var title = selectedDocument?.Title ?? "None";
        var properties = _profile.BaseProperties.ToList();

        properties.Add(new PropertyEntry("Selection", title));
        properties.Add(new PropertyEntry("Document Type", DetectDocumentType(title)));
        properties.Add(new PropertyEntry("Backend", _profile.BackendLabel));
        properties.Add(new PropertyEntry("Mode", _profile.ModeLabel));

        return properties;
    }

    private static string DetectDocumentType(string title)
    {
        if (title.Contains("Policy", StringComparison.Ordinal) ||
            title.Contains("Catalog", StringComparison.Ordinal))
        {
            return "Administration";
        }

        if (title.Contains("Health", StringComparison.Ordinal) ||
            title.Contains("Cluster", StringComparison.Ordinal) ||
            title.Contains("Events", StringComparison.Ordinal))
        {
            return "Operations";
        }

        if (title.Contains("Analysis", StringComparison.Ordinal) ||
            title.Contains("Diff", StringComparison.Ordinal) ||
            title.Contains("Summary", StringComparison.Ordinal))
        {
            return "Analysis";
        }

        if (title.Contains("Shader", StringComparison.Ordinal))
        {
            return "Shader";
        }

        return "Document";
    }
}
