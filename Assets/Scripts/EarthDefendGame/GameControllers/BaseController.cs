using System;
using UnityEngine;

namespace EarthDefendGame.GameControllers
{
    public abstract class BaseController : MonoBehaviour
    {
        public void Init()
        {
            Subscribe();
        }
        
        protected virtual void Subscribe()
        { }

        protected virtual void Unsubscribe()
        { }

        private void OnDestroy()
        {
            Unsubscribe();
        }
    }
}
