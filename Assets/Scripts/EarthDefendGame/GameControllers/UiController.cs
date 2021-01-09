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

        protected override void Subscribe()
        {
            base.Subscribe();

            GameController.planetController.KillCountUpdateEvent += OnPlayerScoreUpdated;
            GameController.planetController.PlanetDestroyEven += ShowDeathPanel;
            GameController.planetController.PowerUpPickUpedEvent += UpdatePowerUpDurationAmount;
            GameController.planetController.PowerUpEndedEvent += TurnOffPowerUpObject;
        }

        protected override void Unsubscribe()
        {
            GameController.planetController.KillCountUpdateEvent -= OnPlayerScoreUpdated;
            GameController.planetController.PlanetDestroyEven -= ShowDeathPanel;
            GameController.planetController.PowerUpPickUpedEvent -= UpdatePowerUpDurationAmount;
            GameController.planetController.PowerUpEndedEvent -= TurnOffPowerUpObject;

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
            levelDurationImage.DOFillAmount(1, GameController.instance.gameConfig.levelDuration);
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
    }
}