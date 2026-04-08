using CStudio.Core.Models;
using CStudio.Core.Services;

namespace CStudio.DagEditAdapter;

public sealed class DagEditSelectionService : ISelectionService
{
    public DocumentTab? SelectedDocument { get; private set; }

    public event Action<DocumentTab?>? SelectedDocumentChanged;

    public void SelectDocument(DocumentTab? document)
    {
        if (EqualityComparer<DocumentTab?>.Default.Equals(SelectedDocument, document))
        {
            return;
        }

        SelectedDocument = document;
        SelectedDocumentChanged?.Invoke(document);
    }
}
