using System;
using System.Collections;
using EarthDefendGame.Configs;
using EarthDefendGame.GameControllers;
using EarthDefendGame.PlanetGuns;
using UnityEngine;

namespace EarthDefendGame.GameComponents
{
    public class PlanetController : BaseController
    {
        public event Action PlanetDestroyEven;
        public event Action KillCountUpdateEvent;
        public event Action PowerUpPickUpedEvent;
        public event Action PowerUpEndedEvent;
        
        [SerializeField] private GameObject planetSprite = null;
        [SerializeField] private BasePlanetGun startingPlanetGun = null;

        private IMovable moveComponent;
        private IShooting gunComponent;
        private BasePlanetGun currentGun;
        private IDamageable damageComponent;
        private ICurable healthComponent;
        private int killCount;
        private Coroutine powerUpRoutine;
        private PowerUpConfig config;

        public float CurrentHealth => healthComponent.CurrentHealth;
        public float MaxHealth => healthComponent.MaxHealth;
        public int KillCount => killCount;

        private void Awake()
        {
            moveComponent = this.GetComponent<IMovable>();
            damageComponent = this.GetComponent<IDamageable>();
            damageComponent.DeathEvent += OnDied;
            currentGun = Instantiate(startingPlanetGun, this.transform.position + new Vector3(0, 2, 0), Quaternion.identity);
            currentGun.transform.SetParent(this.transform);
            gunComponent = currentGun.GetComponent<IShooting>();
            healthComponent = this.GetComponent<ICurable>();
        }

        private void Start()
        {
            config = GameController.instance.gameConfig.powerUpConfig;
        }

        private void Update()
        {
            MoveGun();

            //TODO: probably we should separate input logic.
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gunComponent.Shoot();
            }
        }
        
        protected override void Unsubscribe()
        {
            damageComponent.DeathEvent -= OnDied;
            
            base.Unsubscribe();
        }

        public void IncreaseKillCount()
        {
            killCount++;
            
            KillCountUpdateEvent?.Invoke();
        }
        
        private void MoveGun()
        {
            moveComponent.Move();
        }

        private void OnDied()
        {
            PlanetDestroyEven?.Invoke();

            Destroy(planetSprite.gameObject);
            Destroy(this.gameObject);
        }

        public void ActivePowerUp(BasePlanetGun newGun)
        {
            if (powerUpRoutine != null)
            {
                StopCoroutine(powerUpRoutine);
            }
            
            PowerUpPickUpedEvent?.Invoke();
            EquipNewGun(newGun);
            powerUpRoutine = StartCoroutine(PowerUpActiveRoutine());
        }

        private IEnumerator PowerUpActiveRoutine()
        {
            yield return new WaitForSeconds(config.powerUpDuration);
            EquipNewGun(startingPlanetGun);
            PowerUpEndedEvent?.Invoke();
        }

        private void EquipNewGun(BasePlanetGun newGun)
        {
            var transformToSpawn = currentGun.transform;
            Destroy(currentGun.gameObject);
            currentGun = Instantiate(newGun, transformToSpawn.position, transformToSpawn.rotation);
            currentGun.transform.SetParent(this.transform);
            gunComponent = currentGun.GetComponent<IShooting>();
        }
    }
}
