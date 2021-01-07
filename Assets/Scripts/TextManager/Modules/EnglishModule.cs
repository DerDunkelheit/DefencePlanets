using UnityEngine;

namespace TextManager.Modules
{
    public class EnglishModule : ILanguageModule
    {
        public string TranslateTo(string originalText)
        {
            var translatedText = "translating to English...";
            Debug.Log(translatedText);

            return translatedText;
        }
    }
}
