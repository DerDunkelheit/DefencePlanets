using System;
using UnityEngine;

namespace EarthDefendGame.PlanetGuns
{
    public class SingleShootGun : BasePlanetGun, IShooting
    {
        [SerializeField] private GameObject projectilePrefab = null;
        [SerializeField] private Transform muzzlePoint = null;

        public void Shoot()
        {
            GameObject bullet = Instantiate(projectilePrefab, muzzlePoint.position, muzzlePoint.rotation);
        }
    }
}