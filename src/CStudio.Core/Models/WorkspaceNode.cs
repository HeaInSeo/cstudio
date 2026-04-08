using System.Collections.Generic;

namespace CStudio.Core.Models;

public sealed record WorkspaceNode(string Title, IReadOnlyList<string> Items);
