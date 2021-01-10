using System.Collections;
using System.Collections.Generic;
using EarthDefendGame.GameControllers;
using EarthDefendGame.TextPhrases;
using UnityEngine;

namespace EarthDefendGame.GameManagers
{
    public class EarthLevelManager : MonoBehaviour
    {
        [SerializeField] private PhrasesData introductionPhrases = null;

        private Coroutine levelDurationRoutine;

        private void Start()
        {
            GameController.planetController.PlanetDestroyEven += StopLevelDuration;
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

            ActiveLevelTimer();
        }

        private void ActiveLevelTimer()
        {
            var levelDuration = GameController.instance.gameConfig.levelDuration;
            levelDurationRoutine = StartCoroutine(LevelDurationRoutine(levelDuration));
            GameController.uiController.UpdateLevelDuration();
        }

        private IEnumerator LevelDurationRoutine(float lvlDuration)
        {
            yield return new WaitForSeconds(lvlDuration);
            CompleteLevel();
        }

        private void CompleteLevel()
        {
            //TODO: create rocket fly to another Planet animation.
            Debug.Log("Level completed!");
        }

        private void StopLevelDuration()
        {
            StopCoroutine(levelDurationRoutine);
        }

        private void OnDestroy()
        {
            GameController.planetController.PlanetDestroyEven -= StopLevelDuration;
        }
    }
}