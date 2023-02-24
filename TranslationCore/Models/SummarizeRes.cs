using System.Text.Json.Serialization;

namespace TranslationCore.Models;

public class SummarizeRes
{
    [JsonPropertyName("summary_text")]
    public string? SummaryText { get; set; }
}