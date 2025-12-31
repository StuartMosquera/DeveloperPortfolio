namespace Client.Interfaces;

public interface IThemeService
{
    public event Action? OnChange;

    public string Current { get; }

    public Task InitializeAsync();
    public Task ToggleAsync();
}
