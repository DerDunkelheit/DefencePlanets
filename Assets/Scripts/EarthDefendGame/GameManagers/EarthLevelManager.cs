using System.Collections.Generic;
using EarthDefendGame.GameControllers;
using EarthDefendGame.TextPhrases;
using UnityEngine;

namespace EarthDefendGame.GameManagers
{
    public class EarthLevelManager : MonoBehaviour
    {
        //TODO: came up with better naming.

        [SerializeField] private PhrasesData introductionPhrases = null;

        private void Start()
        {
            GameController.instance.DisableControllers();
            
            StartIntroductionDialog();
        }

        private void StartIntroductionDialog()
        {
            Queue<string> testQueue = new Queue<string>();
            foreach (var phrase in introductionPhrases.phrases)
            {
                testQueue.Enqueue(phrase);
            }
            
            IText introductionText = new EarthLevelIntroductionText(testQueue);
            introductionText.PhrasesEndedEvent += OnIntroductionEnded;
            
            GameController.textPanelController.ShowTextPanel(introductionText);
        }

        private void OnIntroductionEnded()
        {
            GameController.textPanelController.HideTextPanel();
            GameController.instance.EnableAllControllers();
        }
    }
}
