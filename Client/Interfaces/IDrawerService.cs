namespace Client.Interfaces;

public interface IDrawerService
{
    public bool IsOpen { get; }

    public event Action? OnChange;

    public void Toggle();
    public void Close();
}
