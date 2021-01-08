using System;
using DG.Tweening;
using EarthDefendGame.GameControllers;
using EarthDefendGame.PlanetGuns;
using UnityEngine;

namespace EarthDefendGame.PlayerBonuses
{
    public class TripleGunPowerUp : PowerUpBase
    {
        [SerializeField] private BasePlanetGun tripleGun;
        
        protected override void PickUp()
        {
            Destroy(this.gameObject);
            GameController.planetController.ActivePowerUp(tripleGun);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("PlayerBullet"))
            {
                PickUp();
            }
        }
        
    }
}