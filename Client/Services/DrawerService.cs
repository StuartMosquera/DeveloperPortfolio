namespace Client.Services;

public class DrawerService
{
    public bool IsOpen { get; private set; } = false;

    public event Action? OnChange;

    public void Toggle()
    {
        IsOpen = !IsOpen;
        NotifyStateChanged();
    }

    public void Close()
    {
        if (IsOpen)
        {
            IsOpen = false;
            NotifyStateChanged();
        }
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
