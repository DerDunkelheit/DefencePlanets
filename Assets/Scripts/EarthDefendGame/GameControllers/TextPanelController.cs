using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace EarthDefendGame.GameControllers
{
    public class TextPanelController : BaseController
    {
        [SerializeField] private GameObject textPanel = null;
        [SerializeField] private TextMeshProUGUI displayingText = null;
        [SerializeField] private Button continueButton = null;
        [SerializeField] private float hideShowAnimDuration = 0.4f;
        [SerializeField] private float bottomThreshold = -120;

        private RectTransform textPanelRectTransform;
        private IText currentTextModule;
        private Coroutine typeTextRoutine;

        private void Awake()
        {
            textPanelRectTransform = textPanel.GetComponent<RectTransform>();
            textPanelRectTransform.anchoredPosition = new Vector2(0, bottomThreshold);
        }

        protected override void Subscribe()
        {
            base.Subscribe();

            continueButton.onClick.AddListener(PlayNextPhrase);
        }

        protected override void Unsubscribe()
        {
            continueButton.onClick.RemoveListener(PlayNextPhrase);

            base.Unsubscribe();
        }

        public void ShowTextPanel(IText textModule)
        {
            displayingText.text = "";
            currentTextModule = textModule;
            Sequence sequence = DOTween.Sequence();
            sequence.Append(textPanelRectTransform.DOAnchorPosY(0, hideShowAnimDuration)).onComplete += PlayNextPhrase;
        }

        public void HideTextPanel()
        {
            textPanelRectTransform.DOAnchorPosY(bottomThreshold, hideShowAnimDuration);
        }

        private void PlayNextPhrase()
        {
            var phraseToShow = currentTextModule.TryGetNextPhrase();
            if (phraseToShow != null)
            {
                if (typeTextRoutine != null)
                {
                    StopCoroutine(typeTextRoutine);
                }

                typeTextRoutine = StartCoroutine(TypeTextRoutine(phraseToShow));
            }
        }

        private IEnumerator TypeTextRoutine(string textToType)
        {
            displayingText.text = "";
            foreach (char letter in textToType)
            {
                yield return new WaitForSeconds(0.03f);
                displayingText.text += letter;
            }
        }
    }
}