using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace EarthDefendGame.GameControllers
{
    public class LightController : BaseController
    {
        [SerializeField] private Light2D globalLight = null;

        public void SetGlobalLightIntensity(float newIntensity, float duration, TweenCallback callBack = null)
        {
            var tweener = DOTween.To(() => globalLight.intensity, x => globalLight.intensity = x, newIntensity,
                duration);

            if (callBack != null)
            {
                tweener.onComplete += callBack;
            }
        }
    }
}