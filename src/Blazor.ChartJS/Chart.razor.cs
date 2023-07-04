using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.ChartJS;

public partial class Chart
{
    [Parameter, EditorRequired] public object Config { get; set; } = new();
    [Parameter] public double? Width { get; set; }
    [Parameter] public double? Height { get; set; }
    [Parameter] public EventCallback OnChartInitialized { get; set; }

    private readonly string _chartId = $"chart-{Guid.NewGuid()}";

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await Create(Config);
            await OnChartInitialized.InvokeAsync();
        }
    }

    public async ValueTask DisposeAsync()
    {
        await _jsRuntime.InvokeVoidAsync("destroyChart", _chartId);
    }

    private async Task Create(object config)
    {
        Config = config;
        await _jsRuntime.InvokeAsync<object>("createChart", _chartId, config);
    }

    public async Task Rerender()
    {
        await DisposeAsync();
        await Create(Config);
    }

    public async Task Update(object data, bool showAnimation=true)
    {
        var animationString = showAnimation ? "" : "none";

        await _jsRuntime.InvokeAsync<object>("updateChart", _chartId, data, animationString);
    }
}
