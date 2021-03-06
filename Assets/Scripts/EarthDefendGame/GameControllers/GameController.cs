﻿using System;
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
        public static PlanetController planetController;
        public static UiController uiController;
        public static SceneController sceneController;
        public static TextPanelController textPanelController;
        public static LightController lightController;

        public GameConfig gameConfig;

        private List<BaseController> controllers = new List<BaseController>();

        //TODO: came up with better solution.
        public bool IsLevelPlaying { get; set; } = true;

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
            planetController = GameObject.FindWithTag("Player").GetComponent<PlanetController>();
            uiController = this.GetComponent<UiController>();
            sceneController = this.GetComponent<SceneController>();
            textPanelController = this.GetComponent<TextPanelController>();
            lightController = this.GetComponent<LightController>();

            controllers = new List<BaseController>(this.GetComponents<BaseController>()) {planetController};
            InitAllControllers();
            EnableAllControllers();
        }

        private void InitAllControllers()
        {
            foreach (var controller in controllers)
            {
                controller.Init();
            }
        }

        public void EnableAllControllers()
        {
            foreach (var controller in controllers)
            {
                controller.EnableController();
            }
        }

        public void DisableControllers()
        {
            foreach (var controller in controllers)
            {
                controller.DisableController();
            }
        }
    }
}