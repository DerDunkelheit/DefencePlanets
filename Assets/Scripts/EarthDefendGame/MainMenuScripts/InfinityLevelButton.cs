using System;
using UnityEngine;
using UnityEngine.UI;

namespace EarthDefendGame.MainMenuScripts
{
    public class InfinityLevelButton : MonoBehaviour
    {
        public event Action<InfinityLevelTypes> onButtonPressed;

        [SerializeField] private InfinityLevelTypes levelType;
        
        private Button button;

        private void Awake()
        {
            button = this.GetComponent<Button>();
            button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            OnButtonPressed(levelType);
        }

        private void OnButtonPressed(InfinityLevelTypes levelTypes)
        {
            onButtonPressed?.Invoke(levelTypes);
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(OnButtonClick);
        }
    }
}
