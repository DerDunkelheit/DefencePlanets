using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace EarthDefendGame.GameControllers
{
    public class UiController : BaseController
    {
        [SerializeField] private Image healthImage = null;
        [SerializeField] private TextMeshProUGUI playerScoreText = null;
        [SerializeField] private GameObject deathPanel = null;
        
        protected override void Subscribe()
        {
            base.Subscribe();
            
            GameController.PlanetController.KillCountUpdateEvent += OnPlayerScoreUpdated;
            GameController.PlanetController.PlanetDestroyEven += ShowDeathPanel;
        }

        protected override void Unsubscribe()
        {
            GameController.PlanetController.KillCountUpdateEvent -= OnPlayerScoreUpdated;
            GameController.PlanetController.PlanetDestroyEven -= ShowDeathPanel;
            
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

        private void ShowDeathPanel()
        {
            deathPanel.gameObject.SetActive(true);
        }
        
    }
}
