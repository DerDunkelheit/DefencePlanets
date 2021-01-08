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

        private Tween powerUpDurationTween;
        
        protected override void Subscribe()
        {
            base.Subscribe();
            
            GameController.PlanetController.KillCountUpdateEvent += OnPlayerScoreUpdated;
            GameController.PlanetController.PlanetDestroyEven += ShowDeathPanel;
            GameController.PlanetController.PowerUpPickUpedEvent += UpdatePowerUpDurationAmount;
            GameController.PlanetController.PowerUpEndedEvent += TurnOffPowerUpObject;
        }

        protected override void Unsubscribe()
        {
            GameController.PlanetController.KillCountUpdateEvent -= OnPlayerScoreUpdated;
            GameController.PlanetController.PlanetDestroyEven -= ShowDeathPanel;
            GameController.PlanetController.PowerUpPickUpedEvent -= UpdatePowerUpDurationAmount;
            GameController.PlanetController.PowerUpEndedEvent -= TurnOffPowerUpObject;
            
            base.Unsubscribe();
        }

        public void UpdateHealthAmount()
        {
            healthImage.DOFillAmount(GameController.PlanetController.CurrentHealth / GameController.PlanetController.MaxHealth, 0.25f);
        }

        private void OnPlayerScoreUpdated()
        {
            playerScoreText.text = $"Score: {GameController.PlanetController.KillCount}";
        }

        private void UpdatePowerUpDurationAmount()
        {
            powerUpDuration.SetActive(true);
            powerUpDurationImage.fillAmount = 1;
            powerUpDurationTween?.Kill();
            powerUpDurationTween = powerUpDurationImage.DOFillAmount(0, GameController.instance.GameConfig.powerUpConfig.powerUpDuration);
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
