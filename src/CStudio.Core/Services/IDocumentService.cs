using System.Collections.Generic;
using CStudio.Core.Models;

namespace CStudio.Core.Services;

public interface IDocumentService
{
    IReadOnlyList<DocumentTab> GetDocuments();
}
