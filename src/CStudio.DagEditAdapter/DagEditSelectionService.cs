using CStudio.Core.Models;
using CStudio.Core.Services;

namespace CStudio.DagEditAdapter;

public sealed class DagEditSelectionService : ISelectionService
{
    public event EventHandler<SelectedDocumentChangedEventArgs>? SelectedDocumentChanged;

    public DocumentTab? SelectedDocument { get; private set; }

    public void SelectDocument(DocumentTab? document)
    {
        if (EqualityComparer<DocumentTab?>.Default.Equals(SelectedDocument, document))
        {
            return;
        }

        SelectedDocument = document;
        SelectedDocumentChanged?.Invoke(this, new SelectedDocumentChangedEventArgs(document));
    }
}
