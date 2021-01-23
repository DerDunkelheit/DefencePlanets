using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace EarthDefendGame.GameControllers
{
    public class LightController : BaseController
    {
        [SerializeField] private Light2D globalLight = null;

        //TODO: refactoring.
        public void SetGlobalLightIntensity(float newIntensity, float duration, TweenCallback callBack = null)
        {
            var tweener = DOTween.To(() => globalLight.intensity, x => globalLight.intensity = x, newIntensity,
                duration);

            if (callBack != null)
            {
                tweener.onComplete += callBack;
            }
        }

        public void SetGlobalLightIntensityWithDelay(float newIntensity, float duration,
            float delayBeforeChangingIntensity,
            TweenCallback callBack = null)
        {
            StartCoroutine(LightIntensityRoutine(newIntensity, duration, delayBeforeChangingIntensity, callBack));
        }

        private IEnumerator LightIntensityRoutine(float newIntensity, float duration, float delayBeforeChangingIntensity, TweenCallback callBack = null)
        {
            yield return new WaitForSeconds(delayBeforeChangingIntensity);
            
            var tweener = DOTween.To(() => globalLight.intensity, x => globalLight.intensity = x, newIntensity,
                duration);

            if (callBack != null)
            {
                tweener.onComplete += callBack;
            }
        }
    }
}