using System;
using System.Collections.Generic;
using EarthDefendGame.Configs;
using EarthDefendGame.GameComponents;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EarthDefendGame.GameControllers
{
    public class GameController : MonoBehaviour
    {
        public static GameController instance;
        public static AsteroidSpawnerController asteroidSpawnerController;
        public static PlanetController PlanetController;
        public static UiController UiController;
        public static SceneController SceneController;

        public GameConfig GameConfig;

        private List<BaseController> controllers = new List<BaseController>();

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
            
            asteroidSpawnerController = this.GetComponent<AsteroidSpawnerController>();
            PlanetController = GameObject.FindWithTag("Player").GetComponent<PlanetController>();
            UiController = this.GetComponent<UiController>();
            SceneController = this.GetComponent<SceneController>();

            controllers = new List<BaseController>(this.GetComponents<BaseController>());
            InitAllControllers();
        }

        private void InitAllControllers()
        {
            foreach (var controller in controllers)
            {
                controller.Init();
            }
        }
    }
}
