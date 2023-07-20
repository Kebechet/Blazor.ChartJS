# Blazor.ChartJS

This repo contains lean wrapper around [Chart.js](https://www.chartjs.org/) for [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor).

## Motivation: 

Repository [ChartJs.Blazor](https://github.com/mariusmuntean/ChartJs.Blazor) is no longer maintained 
and also it is stuck at old version `chart.js@2.9.4`. 
The lack of maintainers is quite often problem. 
Thats why I have created the leanest wrapper possible. 
This should be quite future proof and if needed also a beginner should be able to bump `chart.js` to newer version or fix potential bug in the wrapper.

## Versioning
- `chart.js` version is part of the package version.
- examples:
    - package version `4.3.0.0` means that `chart.js` version used is `4.3.0`
    - package version `4.3.0.2` means that `chart.js` version used is `4.3.0` and we did 2 bugfixes/improvements in the wrapper

## ChartJS custom changes
- we use `chart.js` version: `4.3.1` *BUT* we have added one extra fix that is not yet merged into `chart.js master` repo.
- Bugs fixed by [PR #11132](https://github.com/chartjs/Chart.js/pull/11132) are [#10932](https://github.com/chartjs/Chart.js/issues/10932), [#11089](https://github.com/chartjs/Chart.js/issues/11089)
- after this PR is merged to master we will fallback to `chart.js` master branch

## Usage example
- our wrapper contains methods: `createChart`, `getChart`, `updateChart`, `clearChartData`, `destroyChart`
- all data and configurations are provided as anonymous objects. Thats why it should be 1:1 with [chart.js docs](https://www.chartjs.org/docs/latest/)




`Index.razor`

```
@using Blazor.ChartJS

<Chart @ref="_chart" Config="_config" OnChartInitialized="() => _isInitializing = false" />
```

`Index.razor.cs`

```
using Blazor.ChartJS;

namespace BlazorChartTest.Pages;

public partial class Index
{
    private Chart? _chart { get; set; }
    private bool _isInitializing = true;

    private readonly dynamic _config = new
    {
        Type = "line",
        Data = new
        {
            Labels = new[] { "Red", "Blue", "Yellow", "Green", "Purple", "Orange" },
            Datasets = new[]
            {
                new
                {
                    Label = "# of Votes",
                    Data = new[] { 12, 19, 3, 5, 2, 3 },
                    BorderWidth = 1
                },
                new
                {
                    Label = "# of Votes",
                    Data = new[] { 12, 19, 3, 5, 2, 3 },
                    BorderWidth = 1
                }
            }
        },
        Options = new
        {
            Responsive = true,
            Scales = new
            {
                X = new
                {
                    Display = true,
                    BeginAtZero = true
                },
                Y = new
                {
                    Display = true,
                    BeginAtZero = true,
                    Grace = "10%"
                }
            },
            Plugins = new
            {
                Legend = new
                {
                    Display = true,
                    Position = "top"
                }
            }
        }
    };

    public async Task Rerender()
    {
        if(_isInitializing)
        {
            return;
        }

        await _chart!.Rerender();
    }

    public async Task Update()
    {
        if(_isInitializing)
        {
            return;
        }

        var data = new
        {
            Labels = new[] { "faast", "Blue", "Yellow", "Green", "Purple", "Orange" },
            Datasets = new[]
            {
                new
                {
                    Label = "# of Votes",
                    Data = new[] { 55, 19, 3, 5, 2, 3 },
                    BorderWidth = 1
                },
                new
                {
                    Label = "# of Votes",
                    Data = new[] { 12, 19, 3, 5, 2, 3 },
                    BorderWidth = 1
                }
            }
        };

        await _chart!.Update(data, false);
    }
}
```

## Contribution is welcome BUT:
- only to improve basic functionality of the wrapper. Purpose of this wrapper is to be as simple as possible.
- to fix bugs
- to automate overall workflow

## TODO
- [ ] add examples
- [ ] automate ChartJS version bump
