using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace EarthDefendGame.MainMenuScripts
{
    public class ButtonHighlightEffect : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            this.transform.DOScale(new Vector3(1.25f, 1.25f, 1.25f), 0.2f);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            this.transform.DOScale(Vector3.one, 0.2f);
        }
    }
}
