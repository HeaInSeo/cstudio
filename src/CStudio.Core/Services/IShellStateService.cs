using System;

namespace CStudio.Core.Services;

public interface IShellStateService
{
    event Action? StateChanged;
}
