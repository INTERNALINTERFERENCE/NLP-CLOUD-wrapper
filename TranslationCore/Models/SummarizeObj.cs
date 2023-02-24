using System.Text.Json.Serialization;

namespace TranslationCore.Models;

public class SummarizeObj
{
    [JsonPropertyName("text")]
    public string? Text { get; set; }
    
    [JsonPropertyName("size")]
    public string Size { get; set; }
}