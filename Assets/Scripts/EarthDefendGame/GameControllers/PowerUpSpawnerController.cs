using System;
using System.Collections;
using EarthDefendGame.Configs;
using UnityEngine;
using Random = UnityEngine.Random;

namespace EarthDefendGame.GameControllers
{
    public class PowerUpSpawnerController : BaseController
    {
        private PowerUpSpawnerConfig config;
        private Coroutine currentCoroutine;

        private void Awake()
        {
            config = GameController.instance.gameConfig.powerUpSpawnerConfig;
        }

        private void Start()
        {
            currentCoroutine = StartCoroutine(SpawningRoutine());
        }

        protected override void Subscribe()
        {
            GameController.planetController.PlanetDestroyEven += DisableSpawningRoutine;
        }

        protected override void Unsubscribe()
        {
            GameController.planetController.PlanetDestroyEven -= DisableSpawningRoutine;
        }

        private IEnumerator SpawningRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(config.minTimeToSpawn, config.maxTimeToSpawn));
                if (isActive)
                {
                    SpawnPowerUp();   
                }
            }
        }

        private void SpawnPowerUp()
        {
            var randomPos = new Vector2(Random.Range(-config.maximumXRange, config.maximumXRange),
                Random.Range(-config.maximumYRange, config.maximumXRange));
            Instantiate(config.possiblePowerUps[Random.Range(0, config.possiblePowerUps.Count)], randomPos,
                Quaternion.identity);
        }

        private void DisableSpawningRoutine()
        {
            StopCoroutine(currentCoroutine);
        }
    }
}