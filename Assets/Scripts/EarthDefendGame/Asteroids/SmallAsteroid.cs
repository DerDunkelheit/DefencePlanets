using System;
using UnityEngine;

namespace EarthDefendGame.Asteroids
{
    public class SmallAsteroid : BaseAsteroid
    {
        [SerializeField] private ParticleSystem destroyParticle = null;
        
        protected override void Awake()
        {
            base.Awake();
            
            damageComponent.DeathEvent += OnDied;
        }

        protected override void OnDied()
        {
            SpawnDestroyEffect();
            AdjustFlyParticle();
            Destroy(this.gameObject);
        }
        
        private void SpawnDestroyEffect()
        {
            var destroyEffect = Instantiate(destroyParticle, this.transform.position, this.transform.rotation);
            Destroy(destroyEffect.gameObject,1.5f);
        }
    }
}
