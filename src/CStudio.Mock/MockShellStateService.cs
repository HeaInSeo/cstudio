using CStudio.Core.Services;

namespace CStudio.Mock;

public sealed class MockShellStateService : IShellStateService
{
    private Action? _stateChanged;

    public event Action? StateChanged
    {
        add => _stateChanged += value;
        remove => _stateChanged -= value;
    }
}
