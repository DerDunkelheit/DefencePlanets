using EarthDefendGame.GameControllers;
using UnityEngine;
using UnityEngine.UI;

namespace EarthDefendGame.MainMenuScripts
{
    public class StartStoryModeButton : MonoBehaviour
    {
        private Button button;
        
        private void Awake()
        {
            button = this.GetComponent<Button>();
            button.onClick.AddListener(StartStory);
        }

        private void StartStory()
        {
            MainMenuController.sceneController.StartStoryLevel();
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(StartStory);
        }
    }
}
