using Microsoft.JSInterop;
using Client.Interfaces;

namespace Client.Services;

public class ThemeService(IJSRuntime jsRuntime) : IThemeService
{
    private readonly IJSRuntime _jsRuntime = jsRuntime;
    private bool _isDark = false;

    public event Action? OnChange;

    public string Current => _isDark ? "dark" : "light";

    public async Task InitializeAsync()
    {
        var theme = await _jsRuntime.InvokeAsync<string>("getTheme");
        _isDark = theme == "dark";
        NotifyStateChanged();
    }

    public async Task ToggleAsync()
    {
        _isDark = !_isDark;
        await _jsRuntime.InvokeVoidAsync("setTheme", Current);
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
