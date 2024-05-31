using Blazor.ChartJS.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;

namespace Blazor.ChartJS;

public partial class Chart
{
    [Parameter, EditorRequired] public object Config { get; set; } = new();
    [Parameter] public string Classes { get; set; } = string.Empty;
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
        await _jsRuntime.InvokeAsync<object>("createChart", _chartId, config.NormalizeObject());
    }

    public async Task Rerender(object? config = null)
    {
        if(config is not null)
        {
            Config = config;
        }

        await DisposeAsync();
        await Create(Config);
    }

    public async Task Update(object data, object options, bool showAnimation = true)
    {
        var animationString = showAnimation ? "" : "none";

        await _jsRuntime.InvokeAsync<object>("updateChart", _chartId, data.NormalizeObject(), options.NormalizeObject(), animationString);
    }

    public async Task UpdateData(object data, bool showAnimation = true)
    {
        var animationString = showAnimation ? "" : "none";

        await _jsRuntime.InvokeAsync<object>("updateChartData", _chartId, data.NormalizeObject(), animationString);
    }

    public async Task UpdateOptions(object optionsData, bool showAnimation = true)
    {
        var animationString = showAnimation ? "" : "none";

        await _jsRuntime.InvokeAsync<object>("updateChartOptions", _chartId, optionsData.NormalizeObject(), animationString);
    }

    public async Task ClearData()
    {
        await _jsRuntime.InvokeAsync<object>("clearChartData", _chartId);
    }
}
