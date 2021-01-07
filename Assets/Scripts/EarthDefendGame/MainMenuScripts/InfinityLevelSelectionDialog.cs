using System;
using EarthDefendGame.GameControllers;
using UnityEngine;
using UnityEngine.UI;

namespace EarthDefendGame.MainMenuScripts
{
    public enum InfinityLevelTypes
    {
        Earth,
        Moon,
        Lava
    };

    public class InfinityLevelSelectionDialog : MonoBehaviour
    {
        [SerializeField] private InfinityLevelButton startEarthLevelButton = null;
        [SerializeField] private InfinityLevelButton startMoonLevelButton = null;
        [SerializeField] private InfinityLevelButton startLavaLevelButton = null;

        private void Awake()
        {
            Subscribe();
        }

        private void Subscribe()
        {
            startEarthLevelButton.onButtonPressed += HandlePressedButton;
            startMoonLevelButton.onButtonPressed += HandlePressedButton;
            startLavaLevelButton.onButtonPressed += HandlePressedButton;
        }

        private void Unsubscribe()
        {
            startEarthLevelButton.onButtonPressed -= HandlePressedButton;
            startMoonLevelButton.onButtonPressed -= HandlePressedButton;
            startLavaLevelButton.onButtonPressed -= HandlePressedButton;
        }

        //TODO: probably i have to create an event and call it here.
        private void HandlePressedButton(InfinityLevelTypes levelType)
        {
            MainMenuController.sceneController.StartInfinityLevel(levelType);
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }
    }
}