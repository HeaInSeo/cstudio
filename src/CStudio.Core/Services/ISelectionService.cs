using System;
using CStudio.Core.Models;

namespace CStudio.Core.Services;

public interface ISelectionService
{
    DocumentTab? SelectedDocument { get; }

    event Action<DocumentTab?>? SelectedDocumentChanged;

    void SelectDocument(DocumentTab? document);
}
