using System.Text.Json;

namespace Blazor.ChartJS.Extensions;

internal static class ObjectExtensions
{
    private static JsonSerializerOptions serializeOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = false
    };

    internal static object NormalizeObject(this object obj)
    {
        var serializedObject = JsonSerializer.Serialize(obj, serializeOptions);
        var deserializedObject = JsonSerializer.Deserialize<object>(serializedObject, serializeOptions);
        return deserializedObject!;
    }
}
