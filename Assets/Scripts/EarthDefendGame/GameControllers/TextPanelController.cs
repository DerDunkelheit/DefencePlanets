using System;
using DG.Tweening;
using UnityEngine;

namespace EarthDefendGame.GameControllers
{
    public class TextPanelController : BaseController
    {
        [SerializeField] private GameObject textPanel = null;
        [SerializeField] private float hideShowAnimDuration = 0.4f;
        [SerializeField] private float buttonThreshold = -120;

        private RectTransform textPanelRectTransform;

        private void Awake()
        {
            textPanelRectTransform = textPanel.GetComponent<RectTransform>();
            textPanelRectTransform.anchoredPosition = new Vector2(0, buttonThreshold);
        }
        
        public void ShowTextPanel()
        {
            textPanelRectTransform.DOAnchorPosY(0, hideShowAnimDuration);
        }

        public void HideTextPanel()
        {
            textPanelRectTransform.DOAnchorPosY(buttonThreshold, hideShowAnimDuration);
        }
    }
}
