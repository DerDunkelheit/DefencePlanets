using EarthDefendGame.GunBullets;
using UnityEngine;

namespace EarthDefendGame.PlanetGuns
{
    public class TripleShootGun : BasePlanetGun, IShooting
    {
        [SerializeField] private GameObject deviationBulletLeft = null;
        [SerializeField] private GameObject deviationBulletRight = null;
        [SerializeField] private GameObject projectilePrefab = null;
        [SerializeField] private Transform firstMuzzlePoint = null;
        [SerializeField] private Transform secondMuzzlePoint = null;
        [SerializeField] private Transform thirdMuzzlePoint = null;
        
        public void Shoot()
        {
           //TODO: create shooting delay and flying to sides effect
           
           GameObject bullet = Instantiate(deviationBulletLeft, firstMuzzlePoint.position, firstMuzzlePoint.rotation);
           GameObject bullet2 = Instantiate(projectilePrefab, secondMuzzlePoint.position, secondMuzzlePoint.rotation);
           GameObject bullet3 = Instantiate(deviationBulletRight, thirdMuzzlePoint.position, thirdMuzzlePoint.rotation);
        }
    }
}
