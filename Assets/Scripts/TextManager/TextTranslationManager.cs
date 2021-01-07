using TextManager.Modules;
using TextManager.Senders;
using UnityEngine;

namespace TextManager
{
    public enum LanguageToTranslate
    {
        English,
        German,
    };

    public class TextTranslationManager : MonoBehaviour
    {
        [SerializeField] private LanguageToTranslate languageToTranslate = LanguageToTranslate.English;
        [TextArea(15, 20)] [SerializeField] private string originalText = "";

        private ILanguageModule currentModule;
        private ISender currentSender;

        private void Awake()
        {
            LanguageData.TryGetModule(languageToTranslate, out currentModule);
            currentSender = this.GetComponent<ISender>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                var translatedText = currentModule?.TranslateTo(originalText);
                currentSender?.Send(translatedText);
            }
        }

        public void ChangeSender(ISender newSender)
        {
            if (newSender == null)
                return;

            currentSender = newSender;
        }
    }
}