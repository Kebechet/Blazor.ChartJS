namespace Blazor.ChartJS.Extensions;

internal static class RandomExtensions
{
    internal static double NextDouble(this Random random,
        double minValue,
        double maxValue)
    {
        return random.NextDouble() * (maxValue - minValue) + minValue;
    }
}
