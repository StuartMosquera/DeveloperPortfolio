namespace Client.Interfaces;

public interface IDrawerService
{
    public event Action? OnChange;

    public bool IsOpen { get; }

    public void Toggle();
    public void Close();
    public Task InitializeAsync();
}
