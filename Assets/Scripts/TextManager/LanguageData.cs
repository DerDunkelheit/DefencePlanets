using System.Collections.Generic;
using TextManager.Modules;

namespace TextManager
{
    public static class LanguageData
    {
        private static Dictionary<LanguageToTranslate, ILanguageModule> possibleLanguageMap =
            new Dictionary<LanguageToTranslate, ILanguageModule>
            {
                {LanguageToTranslate.English, new EnglishModule()},
                {LanguageToTranslate.German, new GermanModule()}
            };

        public static bool TryGetModule(LanguageToTranslate languageToTranslate, out ILanguageModule module)
        {
            if (possibleLanguageMap.ContainsKey(languageToTranslate))
            {
                module = possibleLanguageMap[languageToTranslate];
                return true;
            }

            module = null;
            return false;
        }
    }
}