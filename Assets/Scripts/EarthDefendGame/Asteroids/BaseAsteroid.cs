using System;
using EarthDefendGame.Configs;
using EarthDefendGame.GameControllers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace EarthDefendGame.Asteroids
{
    public abstract class BaseAsteroid : MonoBehaviour
    {
        [SerializeField] private float damage = 1f;
        
        protected IDamageable damageComponent;

        private AsteroidParametersConfig config;
        private float rotationSpeed;
        private float moveSpeed;
        private Vector2 planetPosition;

        protected abstract void OnDied();


        protected virtual void Awake()
        {
            config = GameController.instance.gameConfig.asteroidParametersConfig;
            damageComponent = this.GetComponent<IDamageable>();
            damageComponent.DeathEvent += UpdatePlayerCount;
            planetPosition = GameObject.FindWithTag("Player").transform.position;
            SetInitialParameters();
        }
        
        protected virtual void Update()
        {
            RotateRandomly();
            MoveToPlanet();
        }

        private void SetInitialParameters()
        {
            var rotationSideRoll = Random.Range(0, 2);
            rotationSpeed = rotationSideRoll == 0
                ? Random.Range(config.minLeftRotationSpeed, config.maxLeftRotationSpeed)
                : Random.Range(config.minRightRotationSpeed, config.maxRightRotationSpeed);

            moveSpeed = Random.Range(config.minMoveSpeed, config.maxMoveSpeed);
        }

        private void RotateRandomly()
        {
            this.transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
        }

        private void MoveToPlanet()
        {
            this.transform.position =
                Vector3.MoveTowards(this.transform.position, planetPosition, moveSpeed * Time.deltaTime);
        }

        private void UpdatePlayerCount()
        {
            GameController.planetController.IncreaseKillCount();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                if (other.TryGetComponent<IDamageable>(out var damageComp))
                {
                    damageComp.TakeDamage(damage);
                    Destroy(this.gameObject);
                }
            }
        }

        private void OnDestroy()
        {
            damageComponent.DeathEvent -= UpdatePlayerCount;
        }
    }
}