using UnityEngine;
using Random = UnityEngine.Random;

namespace EarthDefendGame.Asteroids
{
    public class BigAsteroid : BaseAsteroid
    {
        [SerializeField] private GameObject smallAsteroidPrefab = null;
        [SerializeField] private int minAmountToSpawn = 1;
        [SerializeField] private int maxAmountToSpawn = 3;

        protected override void Awake()
        {
            base.Awake();

            damageComponent.DeathEvent += OnDied;
        }

        protected override void OnDied()
        {
            Destroy(this.gameObject);
            SpawnSmallAsteroids();
        }

        private void SpawnSmallAsteroids()
        {
            var amountToSpawn = Random.Range(minAmountToSpawn, (maxAmountToSpawn + 1));

            for (int i = 0; i < amountToSpawn; i++)
            {
                Vector2 randomSpawnThreshold = new Vector2(Random.Range(-1.5f, 1.5f), Random.Range(-1.5f, 1.5f));
                Instantiate(smallAsteroidPrefab, (Vector2) this.transform.position + randomSpawnThreshold,
                    Quaternion.identity);
            }
        }
    }
}