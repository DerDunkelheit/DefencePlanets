using UnityEngine;

namespace EarthDefendGame.TextPhrases
{
    [CreateAssetMenu(menuName = "PhrasesData",fileName = "NewPhrasesData")]
    public class PhrasesData : ScriptableObject
    {
        [TextArea(5,10)]
        public string[] phrases;
    }
}
