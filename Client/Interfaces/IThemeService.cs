namespace Client.Interfaces;

public interface IThemeService
{
    public bool IsDark { get; }

    public event Action? OnChange;

    public void Toggle();
}
