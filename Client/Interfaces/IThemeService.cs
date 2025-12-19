namespace Client.Interfaces;

public interface IThemeService
{
    public bool IsDarkTheme { get; }

    public event Action? OnChange;

    public void ToggleTheme();
}
