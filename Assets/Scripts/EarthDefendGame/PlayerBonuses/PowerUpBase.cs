using System;
using DG.Tweening;
using UnityEngine;

namespace EarthDefendGame.PlayerBonuses
{
    public abstract class PowerUpBase : MonoBehaviour
    {
        [SerializeField] private float lifeTime = 2.5f;

        private SpriteRenderer spriteRenderer;
        private Color initialColor;

        protected abstract void PickUp();


        private void Awake()
        {
            spriteRenderer = this.GetComponent<SpriteRenderer>();
            initialColor = spriteRenderer.color;
            this.transform.localScale = Vector3.zero;

            SetupBehaviourSequence();
        }

        private void SetupBehaviourSequence()
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOScale(new Vector3(1.6f,1.6f,1.6f), 0.5f))
                .Append(transform.DOScale(Vector3.one, 0.4f))
                .Append(spriteRenderer.DOColor(new Color(initialColor.r, initialColor.g, initialColor.b, 0), lifeTime))
                .onComplete += () => Destroy(this.gameObject);
        }
    }
}