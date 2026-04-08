using System.Collections.Generic;
using CStudio.Core.Models;

namespace CStudio.Core.Services;

public interface IPropertyPanelService
{
    IReadOnlyList<PropertyEntry> GetProperties(DocumentTab? selectedDocument);
}
