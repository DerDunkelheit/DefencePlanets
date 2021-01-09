using System;
using System.Collections.Generic;

namespace EarthDefendGame.TextPhrases
{
    public class EarthLevelIntroductionText : IText
    {
        public event Action PhrasesEndedEvent;
        
        public Queue<string> Phrases { get; }

        public EarthLevelIntroductionText(Queue<string> introductionPhrases)
        {
            Phrases = introductionPhrases;
        }

        public string TryGetNextPhrase()
        {
            if (Phrases.Count == 0)
            {
                PhrasesEndedEvent?.Invoke();
                return null;
            }

            return Phrases.Dequeue();
        }
        
    }
}
