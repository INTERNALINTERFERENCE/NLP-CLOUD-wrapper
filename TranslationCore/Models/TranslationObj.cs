using System.Text.Json.Serialization;

namespace TranslationCore.Models;
public class TranslationObj
{
    [JsonPropertyName("text")]
    public string? Text { get; set; }
    
    [JsonPropertyName("source")]
    public string? Source { get; set; }
    
    [JsonPropertyName("target")]
    public string? Target { get; set; }
}