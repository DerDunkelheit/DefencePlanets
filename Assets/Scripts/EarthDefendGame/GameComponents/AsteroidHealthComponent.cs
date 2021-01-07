using System;
using UnityEngine;

namespace EarthDefendGame.GameComponents
{
    public class AsteroidHealthComponent : MonoBehaviour,IDamageable
    {
        public event Action DeathEvent;

        [SerializeField] private float startingHealth = 1;

        private float currentHealth;
        private bool isAlive;

        private void Awake()
        {
            currentHealth = startingHealth;
            isAlive = true;
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                TriggerDeathEvent();
            }
        }

        private void TriggerDeathEvent()
        {
            if (isAlive)
            {
                DeathEvent?.Invoke();
                isAlive = false;
            }
        }
    }
}
