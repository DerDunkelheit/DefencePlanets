using System;
using UnityEngine;

namespace EarthDefendGame.GunBullets
{
    public class DeviationBullet : BasePlayerBullet
    {
        [SerializeField] private float turnAngel = 1f;
        [SerializeField] private bool deviationToRight = true;
        
        private void Start()
        {
            if (deviationToRight)
            {
                transform.Rotate(0, 0, -turnAngel);
            }
            else
            {
                transform.Rotate(0, 0, turnAngel);
            }
        }
    }
}