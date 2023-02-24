using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TranslationCore.Extensions;

namespace TranslationCore;
public class NlpTranslationService
{
    private readonly string _apiKey;
    private readonly Uri _uri = new("https://api.nlpcloud.io/v1/nllb-200-3-3b/translation");

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

        var httpResult = await client.PostAsync(_uri, payload);

        return await httpResult.Content
            .ReadFromJsonAsync<TranslationRes>();
    }
}