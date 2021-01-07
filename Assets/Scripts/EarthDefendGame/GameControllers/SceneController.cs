using System;
using EarthDefendGame.MainMenuScripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace EarthDefendGame.GameControllers
{
    public class SceneController : BaseController
    {
        [SerializeField] private Button restartButton = null;
        
        protected override void Subscribe()
        {
            base.Subscribe();
            
            if (restartButton != null)
            {
                restartButton.onClick.AddListener(RestartScene);
            }
        }

        protected override void Unsubscribe()
        {
            if (restartButton != null)
            {
                restartButton.onClick.RemoveListener(RestartScene);
            }

            base.Unsubscribe();
        }

        private void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        //TODO: probably i need to replace this hardcode to config.
        public void StartInfinityLevel(InfinityLevelTypes levelType)
        {
            if (levelType == InfinityLevelTypes.Moon)
            {
                Debug.Log($"{levelType} is in the work now");
                return;
            }
            else if (levelType == InfinityLevelTypes.Lava)
            {
                Debug.Log($"{levelType} is in the work now");
                return;
            }
            
            SceneManager.LoadScene($"{levelType}SceneInfinity");
        }
    }
}
