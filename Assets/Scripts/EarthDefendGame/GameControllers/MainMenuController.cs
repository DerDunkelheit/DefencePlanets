using System;
using UnityEngine;

namespace EarthDefendGame.GameControllers
{
    public class MainMenuController : BaseController
    {
        public static SceneController sceneController;

        private void Awake()
        {
            sceneController = this.GetComponent<SceneController>();
        }
    }
}
