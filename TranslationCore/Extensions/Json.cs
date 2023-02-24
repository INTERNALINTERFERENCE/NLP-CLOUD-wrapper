using System.Text.Json;
using System.Text.Json.Serialization;

namespace TranslationCore.Extensions;

public static class Json
{
    public static string ToJson<T>(this T obj)
        => JsonSerializer.Serialize(obj);
}