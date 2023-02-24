using System.Text.Json.Serialization;

namespace TranslationCore.Models;
public class TranslationRes
{
    [JsonPropertyName("translation_text")]
    public string? TranslationText { get; set; }
}