using Microsoft.AspNetCore.Mvc;
using TranslationCore;

namespace TranslationApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TranslationController : ControllerBase
{
    private readonly ILogger<TranslationController> _logger;
    private readonly NlpTranslationService _nlpTranslationService;
    private readonly Dictionary<string, string> _languages = new()
    {
        {"ru", "rus_Cyrl"},
        {"en", "eng_Latn"}
    };

    public TranslationController(
        ILogger<TranslationController> logger, 
        NlpTranslationService nlpTranslationService)
    {
        _logger = logger;
        _nlpTranslationService = nlpTranslationService;
    }
    
    [HttpPost(Name = "PostTranslationController")]
    public async Task<ActionResult> Post(
        string translateText, 
        string source,
        string target)
    {
        _languages.TryGetValue(source, out var dSource);
        _languages.TryGetValue(target, out var dTarget);
        
        var translatedText = await _nlpTranslationService
            .Translate(translateText, dSource, dTarget);

        return Ok(translatedText);
    }
}