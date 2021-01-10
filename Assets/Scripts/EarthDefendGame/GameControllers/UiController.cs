using System;
using DG.Tweening;
using EarthDefendGame.GameComponents;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace EarthDefendGame.GameControllers
{
    public class UiController : BaseController
    {
        [SerializeField] private Image healthImage = null;
        [SerializeField] private GameObject powerUpDuration = null;
        [SerializeField] private Image powerUpDurationImage = null;
        [SerializeField] private TextMeshProUGUI playerScoreText = null;
        [SerializeField] private GameObject deathPanel = null;
        [SerializeField] private GameObject levelDuration = null;
        [SerializeField] private Image levelDurationImage = null;

        private Tween powerUpDurationTween;
        private Tween levelDurationTween;
        
        //TODO: create an interface witch is called IStoryManager or something like that, and create there an event, on Level completed and create subscribe instead of public methods.

        protected override void Subscribe()
        {
            base.Subscribe();

            GameController.planetController.KillCountUpdateEvent += OnPlayerScoreUpdated;
            GameController.planetController.PlanetDestroyEven += ShowDeathPanel;
            GameController.planetController.PowerUpPickUpedEvent += UpdatePowerUpDurationAmount;
            GameController.planetController.PowerUpEndedEvent += TurnOffPowerUpObject;
            GameController.planetController.PlanetDestroyEven += StopLevelDurationProcess;
        }

        protected override void Unsubscribe()
        {
            GameController.planetController.KillCountUpdateEvent -= OnPlayerScoreUpdated;
            GameController.planetController.PlanetDestroyEven -= ShowDeathPanel;
            GameController.planetController.PowerUpPickUpedEvent -= UpdatePowerUpDurationAmount;
            GameController.planetController.PowerUpEndedEvent -= TurnOffPowerUpObject;
            GameController.planetController.PlanetDestroyEven -= StopLevelDurationProcess;

            base.Unsubscribe();
        }

        public void UpdateHealthAmount()
        {
            healthImage.DOFillAmount(
                GameController.planetController.CurrentHealth / GameController.planetController.MaxHealth, 0.25f);
        }

        //TODO: create event for that.
        public void UpdateLevelDuration()
        {
            levelDuration.SetActive(true);
            levelDurationTween = levelDurationImage.DOFillAmount(1, GameController.instance.gameConfig.levelDuration);
        }

        public void DisableAllUi()
        {
            powerUpDuration.SetActive(false);
            playerScoreText.gameObject.SetActive(false);
            levelDuration.SetActive(false);
        }

        private void OnPlayerScoreUpdated()
        {
            playerScoreText.text = $"Score: {GameController.planetController.KillCount}";
        }

        private void UpdatePowerUpDurationAmount()
        {
            powerUpDuration.SetActive(true);
            powerUpDurationImage.fillAmount = 1;
            powerUpDurationTween?.Kill();
            powerUpDurationTween =
                powerUpDurationImage.DOFillAmount(0, GameController.instance.gameConfig.powerUpConfig.powerUpDuration);
        }

        private void TurnOffPowerUpObject()
        {
            powerUpDuration.SetActive(false);
        }

        private void ShowDeathPanel()
        {
            deathPanel.gameObject.SetActive(true);
        }

        private void StopLevelDurationProcess()
        {
            levelDurationTween?.Kill();
        }
    }
}