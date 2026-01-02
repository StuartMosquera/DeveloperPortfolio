using Microsoft.JSInterop;
using Client.Interfaces;

namespace Client.Services;

public class DrawerService(IJSRuntime jsRuntime) : IDrawerService, IDisposable
{
    private readonly IJSRuntime _jsRuntime = jsRuntime;
    private DotNetObjectReference<DrawerService>? _objRef;

    public event Action? OnChange;

    public bool IsOpen { get; private set; } = false;

    public void Toggle()
    {
        IsOpen = !IsOpen;
        NotifyStateChanged();
    }

    [JSInvokable]
    public void Close()
    {
        if (IsOpen)
        {
            IsOpen = false;
            NotifyStateChanged();
        }
    }

    public void Dispose() => _objRef?.Dispose();

    public async Task InitializeAsync()
    {
        if (_objRef is not null)
            return;

        _objRef = DotNetObjectReference.Create(this);
        await _jsRuntime.InvokeVoidAsync("watchResize", _objRef, 768);
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
