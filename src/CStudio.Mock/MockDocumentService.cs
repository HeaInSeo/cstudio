using CStudio.Core.Models;
using CStudio.Core.Services;

namespace CStudio.Mock;

public sealed class MockDocumentService : IDocumentService
{
    private readonly MockWorkspaceProfile _profile;

    public MockDocumentService()
        : this(MockWorkspaceProfiles.CreateDefault())
    {
    }

    public MockDocumentService(MockWorkspaceProfile profile)
    {
        _profile = profile;
    }

    public IReadOnlyList<DocumentTab> GetDocuments() => _profile.Documents;
}
