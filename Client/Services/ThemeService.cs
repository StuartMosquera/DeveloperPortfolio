using Client.Interfaces;

namespace Client.Services;

public class ThemeService : IThemeService
{
    public bool IsDark { get; private set; } = false;

    public event Action? OnChange;

    public void Toggle()
    {
        IsDark = !IsDark;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
