using System.Net.Http.Json;
using System.Text;
using TranslationCore.Extensions;
using TranslationCore.Models;

namespace TranslationCore;
public class NlpTranslationService
{
    private readonly string _apiKey;
    private readonly Uri _translationUri = new("https://api.nlpcloud.io/v1/nllb-200-3-3b/translation");
    private readonly Uri _summarizeUri = new("https://api.nlpcloud.io/v1/bart-large-cnn/summarization");
    
    public NlpTranslationService(string apiKey)
    {
        _apiKey = apiKey;
    }
    
    public async Task<TranslationRes?> Translate(
        string text,
        string? source,
        string? target)
    {
        using var client = new HttpClient();
        
        client.DefaultRequestHeaders.Add("Authorization", "Token " + _apiKey);
        
        var translationObject = new TranslationObj
        {
            Text = text,
            Source = source,
            Target = target
        };
        
        var payload = new StringContent(
            translationObject.ToJson(),
            Encoding.UTF8,
            "application/json");

        var httpResult = await client.PostAsync(_translationUri, payload);

        return await httpResult.Content
            .ReadFromJsonAsync<TranslationRes>();
    }

    public async Task<SummarizeRes?> Summarize(string text, string size)
    {
        using var client = new HttpClient();
        
        client.DefaultRequestHeaders.Add("Authorization", "Token " + _apiKey);
        
        var translationObject = new SummarizeObj
        {
            Text = text,
            Size = size
        };
        
        var payload = new StringContent(
            translationObject.ToJson(),
            Encoding.UTF8,
            "application/json");

        var httpResult = await client.PostAsync(_summarizeUri, payload);

        return await httpResult.Content
            .ReadFromJsonAsync<SummarizeRes>();
    }
}