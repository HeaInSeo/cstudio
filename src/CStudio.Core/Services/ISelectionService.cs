using System;
using CStudio.Core.Models;

namespace CStudio.Core.Services;

public interface ISelectionService
{
    event EventHandler<SelectedDocumentChangedEventArgs>? SelectedDocumentChanged;

    DocumentTab? SelectedDocument { get; }

    void SelectDocument(DocumentTab? document);
}
