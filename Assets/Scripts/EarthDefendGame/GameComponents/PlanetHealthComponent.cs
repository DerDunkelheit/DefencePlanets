using System;
using EarthDefendGame.GameControllers;
using UnityEngine;

namespace EarthDefendGame.GameComponents
{
    public class PlanetHealthComponent : MonoBehaviour, ICurable, IDamageable
    {
        public event Action HealthChangeEvent;
        public event Action DeathEvent;

        [SerializeField] private float startingHealth = 5f;

        private float currentHealth;

        public float CurrentHealth => currentHealth;
        public float MaxHealth => startingHealth;

        private void Awake()
        {
            currentHealth = startingHealth;
        }

        private void Start()
        {
            HealthChangeEvent += OnHealthChanged;
        }

        public void RestoreHealth(float amount)
        {
            currentHealth += amount;

            if (currentHealth > startingHealth)
            {
                currentHealth = startingHealth;
            }

            TriggerHealthChangeEvent();
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                TriggerDeathEvent();
            }

            TriggerHealthChangeEvent();
        }

        private void TriggerDeathEvent()
        {
            DeathEvent?.Invoke();
        }

        private void TriggerHealthChangeEvent()
        {
            HealthChangeEvent?.Invoke();
        }
        
        private void OnHealthChanged()
        {
            GameController.uiController.UpdateHealthAmount();
        }

        private void OnDestroy()
        {
            HealthChangeEvent -= OnHealthChanged;
        }
    }
}