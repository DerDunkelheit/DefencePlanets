using System;
using UnityEngine;

namespace EarthDefendGame.Asteroids
{
    public class SmallAsteroid : BaseAsteroid
    {
        protected override void Awake()
        {
            base.Awake();
            
            damageComponent.DeathEvent += OnDied;
        }

        protected override void OnDied()
        {
            Destroy(this.gameObject);
        }
    }
}
