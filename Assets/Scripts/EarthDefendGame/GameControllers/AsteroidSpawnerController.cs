using System.Collections;
using System.Collections.Generic;
using EarthDefendGame.Configs;
using UnityEngine;
using Random = UnityEngine.Random;

namespace EarthDefendGame.GameControllers
{
    public class AsteroidSpawnerController : BaseController
    {
        [SerializeField] private Transform topSpawnPoint = null;
        [SerializeField] private Transform leftSpawnPoint = null;
        [SerializeField] private Transform bottomSpawnPoint = null;
        [SerializeField] private Transform rightSpawnPoint = null;

        private AsteroidSpawnerConfig config;
        private Coroutine spawningRoutine;

        private void Awake()
        {
            config = GameController.instance.gameConfig.asteroidSpawnerConfig;
            spawningRoutine = StartCoroutine(SpawnAsteroidRoutine());
        }
        
        protected override void Subscribe()
        {
            base.Subscribe();
            
            GameController.planetController.PlanetDestroyEven += StopSpawningAsteroids;
        }
        
        private void StopSpawningAsteroids()
        {
            StopCoroutine(spawningRoutine);
        }

        private IEnumerator SpawnAsteroidRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(config.minTimeToSpawn, config.maxTimeToSpawn));
                SpawnAsteroid();
            }
        }

        private void SpawnAsteroid()
        {
            var currentSide = Random.Range(0, 4);
            var additionalRange = Random.Range(config.minAdditionalToSpawnSide, config.maxAdditionalToSpawnSide);

            switch (currentSide)
            {
                case 0:
                    Debug.Log($"Spawning at top");
                    Instantiate(config.possibleAsteroids[Random.Range(0, config.possibleAsteroids.Count)],
                        new Vector3(topSpawnPoint.position.x + additionalRange, topSpawnPoint.position.y, 0),
                        Quaternion.identity);
                    break;

                case 1:
                    Debug.Log($"Spawning at left");
                    Instantiate(config.possibleAsteroids[Random.Range(0, config.possibleAsteroids.Count)],
                        new Vector3(leftSpawnPoint.position.x, leftSpawnPoint.position.y + additionalRange, 0),
                        Quaternion.identity);
                    break;

                case 2:
                    Debug.Log($"Spawning at bottom");
                    Instantiate(config.possibleAsteroids[Random.Range(0, config.possibleAsteroids.Count)],
                        new Vector3(bottomSpawnPoint.position.x + additionalRange, bottomSpawnPoint.position.y, 0),
                        Quaternion.identity);
                    break;

                case 3:
                    Debug.Log($"Spawning at right");
                    Instantiate(config.possibleAsteroids[Random.Range(0, config.possibleAsteroids.Count)],
                        new Vector3(rightSpawnPoint.position.x, rightSpawnPoint.position.y + additionalRange, 0),
                        Quaternion.identity);
                    break;
            }
        }

        protected override void Unsubscribe()
        {
            GameController.planetController.PlanetDestroyEven -= StopSpawningAsteroids;
            
            base.Unsubscribe();
        }
    }
}