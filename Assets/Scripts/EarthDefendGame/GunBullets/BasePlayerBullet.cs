using System;
using UnityEngine;

namespace EarthDefendGame.GunBullets
{
    public class BasePlayerBullet : MonoBehaviour
    {
        [SerializeField] protected float damage = 1;
        [SerializeField] protected float moveSpeed = 15f;

        private void Awake()
        {
            Invoke(nameof(SelfDestroy), 3f);
        }

        private void Update()
        {
            this.transform.Translate(Vector2.up * (moveSpeed * Time.deltaTime));
        }

        private void SelfDestroy()
        {
            Destroy(this.gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag($"Enemy"))
            {
                if (other.TryGetComponent<IDamageable>(out var damageComponent))
                {
                    damageComponent.TakeDamage(damage);
                    Destroy(this.gameObject);
                }
            }
        }
    }
}