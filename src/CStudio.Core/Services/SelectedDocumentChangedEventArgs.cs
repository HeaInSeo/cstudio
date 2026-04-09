using System;
using CStudio.Core.Models;

namespace CStudio.Core.Services;

public sealed class SelectedDocumentChangedEventArgs : EventArgs
{
    public SelectedDocumentChangedEventArgs(DocumentTab? selectedDocument)
    {
        SelectedDocument = selectedDocument;
    }

    public DocumentTab? SelectedDocument { get; }
}
