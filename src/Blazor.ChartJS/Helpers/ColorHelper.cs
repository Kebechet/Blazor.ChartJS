using Blazor.ChartJS.Extensions;
using System.Globalization;

namespace Blazor.ChartJS.Helpers;

public static class ColorHelper
{
    public static readonly List<string> DefaultColors = new() {
        "#36A2EB", //ChartJS - blue
		"#FF6384", //ChartJS - red
		"#4BC0C0", //ChartJS - green
		"#FF9F40", //ChartJS - orange
		"#9966FF", //ChartJS - purple
		"#FFCD56", //ChartJS - yellow
		"#C9CBCF", //ChartJS - gray
		"#F54291", //Hot Pink
		"#8DE368", //Lime Green
		"#4A90E2"  //Light Sky Blue
	};

    public static string GetColorFromRGBHEX(string rgbHex, double alpha = 1)
    {
        rgbHex = rgbHex
            .Trim()
            .Replace("#", string.Empty);

        if (rgbHex.Length != 6)
        {
            throw new ArgumentException("Invalid length of RGB hexadecimal color value. Must be 6 characters (without #).");
        }

        var r = byte.Parse(rgbHex.Substring(0, 2), NumberStyles.HexNumber);
        var g = byte.Parse(rgbHex.Substring(2, 2), NumberStyles.HexNumber);
        var b = byte.Parse(rgbHex.Substring(4, 2), NumberStyles.HexNumber);

        return GetColorFromRGBA(r, g, b, alpha);
    }

    /// <summary>
    /// Produces a string in the form 'rgba(r, g, b, alpha)' with the provided rgb and alpha values.
    /// </summary>
    /// <param name="r"></param>
    /// <param name="g"></param>
    /// <param name="b"></param>
    /// <param name="alpha"></param>
    public static string GetColorFromRGBA(byte r, byte g, byte b, double alpha = 1)
    {
        return $"rgba({r}, {g}, {b}, {alpha.ToString(CultureInfo.InvariantCulture)})";
    }

    /// <summary>
    /// Produces a string of the form 'rgba(r, g, b, alpha)' with random values for rgb and alpha.
    /// </summary>
    public static string GetRandomColor(bool randomOpacity=false)
    {
        var rgb = new byte[3];
        var alpha = 1D;

        Random.Shared.NextBytes(rgb);

        if (randomOpacity)
        {
            alpha = Random.Shared.NextDouble(0.1, 1);
        }

        return GetColorFromRGBA(rgb[0], rgb[1], rgb[2], alpha);
    }

    /// <summary>
    /// Generates the corresponding string representation of a <see cref="System.Drawing.Color" /> object.
    /// It's returned as rgba string.
    /// </summary>
    public static string GetColorFromDrawingColor(System.Drawing.Color color)
    {
        return GetColorFromRGBA(color.R, color.G, color.B, (double)color.A / byte.MaxValue);
    }
}
