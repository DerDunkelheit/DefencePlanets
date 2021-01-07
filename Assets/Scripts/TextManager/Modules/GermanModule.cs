using UnityEngine;

namespace TextManager.Modules
{
    public class GermanModule : ILanguageModule
    {
        public string TranslateTo(string originalText)
        {
            var translatedText = "translating to German...";
            Debug.Log(translatedText);

            return translatedText;
        }
    }
}
