using EarthDefendGame.MainMenuScripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace EarthDefendGame.GameControllers
{
    public class SceneController : BaseController
    {
        public void RestartScene()
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

        //TODO: read levels from config or csv file.
        public void StartStoryLevel()
        {
            SceneManager.LoadScene("EarthSceneStory");
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
