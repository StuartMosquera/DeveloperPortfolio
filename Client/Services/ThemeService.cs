using Client.Interfaces;

namespace Client.Services;

public class ThemeService : IThemeService
{
    public bool IsDarkTheme { get; private set; } = false;

    public event Action? OnChange;

    public void ToggleTheme()
    {
        IsDarkTheme = !IsDarkTheme;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
