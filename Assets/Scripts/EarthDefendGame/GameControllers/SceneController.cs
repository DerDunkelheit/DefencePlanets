using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace EarthDefendGame.GameControllers
{
    public class SceneController : BaseController
    {
        [SerializeField] private Button restartButton = null;

        private void Awake()
        {
            restartButton.onClick.AddListener(RestartScene);
        }

        private void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void OnDestroy()
        {
            restartButton.onClick.RemoveListener(RestartScene);
        }
    }
}
