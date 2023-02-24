
using System;
using TranslationCore;

// paste your api key
var client = new NlpTranslationClient("");

// from russian to english
var res = await client.Translate(text: "", source: "rus_Cyrl", target: "eng_Latn");

Console.Write(res?.TranslationText);