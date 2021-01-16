using System.Collections.Generic;
using EarthDefendGame.Asteroids;
using EarthDefendGame.PlayerBonuses;
using UnityEngine;

namespace EarthDefendGame.Configs
{
    [System.Serializable]
    public class AsteroidParametersConfig
    {
        public float minMoveSpeed = 4f;
        public float maxMoveSpeed = 7f;
        public float minLeftRotationSpeed = -25f;
        public float maxLeftRotationSpeed = -100f;
        public float minRightRotationSpeed = 25f;
        public float maxRightRotationSpeed = 100;
    }

    [System.Serializable]
    public class AsteroidSpawnerConfig
    {
        public List<BaseAsteroid> possibleAsteroids = new List<BaseAsteroid>();
        public float minTimeToSpawn = 1f;
        public float maxTimeToSpawn = 4f;
        public float minAdditionalToSpawnSide = -10;
        public float maxAdditionalToSpawnSide = 10;
        [Tooltip("In percents")] public int chaneToSpawnDoubleAsteroid = 15;
    }

    [System.Serializable]
    public class PowerUpSpawnerConfig
    {
        public List<PowerUpBase> possiblePowerUps = new List<PowerUpBase>();
        public float minTimeToSpawn = 4f;
        public float maxTimeToSpawn = 15f;
        public float maximumXRange = 17;
        public float maximumYRange = 12f;
    }

    [System.Serializable]
    public class PowerUpConfig
    {
        public float powerUpDuration = 10;
    }

    [CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [Tooltip("In seconds")] public float levelDuration = 180;
        public AsteroidParametersConfig asteroidParametersConfig;
        public AsteroidSpawnerConfig asteroidSpawnerConfig;
        public PowerUpSpawnerConfig powerUpSpawnerConfig;
        public PowerUpConfig powerUpConfig;
    }
}