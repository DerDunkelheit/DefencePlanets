using System;
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

        private Animator animator;
        private Coroutine levelDurationRoutine;
        private static readonly int LevelEnding = Animator.StringToHash("LevelEnding");

        private void Awake()
        {
            animator = this.GetComponent<Animator>();
        }

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

        //TODO: probably event would be good here.
        private void CompleteLevel()
        {
            GameController.instance.IsLevelPlaying = false;
            GameController.instance.DisableControllers();
            GameController.uiController.DisableAllUi();
            animator.SetTrigger(LevelEnding);
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