using CStudio.Core.Services;

namespace CStudio.Mock;

public sealed class MockShellStateService : IShellStateService
{
    private EventHandler? _stateChanged;

    public event EventHandler? StateChanged
    {
        add => _stateChanged += value;
        remove => _stateChanged -= value;
    }
}
