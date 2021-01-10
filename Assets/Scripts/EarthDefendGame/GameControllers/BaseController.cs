using System;
using UnityEngine;

namespace EarthDefendGame.GameControllers
{
    public abstract class BaseController : MonoBehaviour
    {
        protected bool isActive;
        
        public void Init()
        {
            Subscribe();
        }

        public void EnableController()
        {
            isActive = true;
        }

        public void DisableController()
        {
            isActive = false;
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
