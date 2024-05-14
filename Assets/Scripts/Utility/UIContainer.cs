using System.Collections;
using UnityEngine;

namespace CodeSample_Currencies.Utility
{
    [RequireComponent(typeof(CanvasGroup))]
    public class UIContainer : MonoBehaviour
    {
        public enum VisibilityState : byte
        {
            None = 0,
            Hidden = 1,
            Showing = 2,
            Visible = 3,
            Hiding = 4,
        }

        [field: SerializeField] VisibilityState initialVisibility;
        [field: SerializeField] float showDuration;
        [field: SerializeField] float hideDuration;

        CanvasGroup canvasGroup;

        protected void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        protected void Start()
        {
            switch (initialVisibility)
            {
                case VisibilityState.Hidden:
                    canvasGroup.alpha = 0;
                    canvasGroup.interactable = false;
                    canvasGroup.blocksRaycasts = false;
                    break;
                case VisibilityState.Visible:
                    canvasGroup.alpha = 1;
                    canvasGroup.interactable = true;
                    canvasGroup.blocksRaycasts = true;
                    break;
                case VisibilityState.Showing:
                    Show();
                    break;
                case VisibilityState.Hiding:
                    Hide();
                    break;
            }
        }

        public virtual void Show(bool isAnimated = true)
        {
            if (isAnimated)
            {
                StartCoroutine(ShowCoroutine());
            }
            else
            {
                canvasGroup.alpha = 1;
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
            }
        }

        public virtual void Hide(bool isAnimated = true)
        {
            if (isAnimated)
            {
                StartCoroutine(HideCoroutine());
            }
            else
            {
                canvasGroup.alpha = 0;
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
            }
        }

        protected virtual IEnumerator ShowCoroutine()
        {
            float currentTime = 0f;
            while (currentTime < showDuration)
            {
                currentTime += Time.deltaTime;
                canvasGroup.alpha = currentTime / showDuration;
                yield return null;
            }
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }

        protected virtual IEnumerator HideCoroutine()
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            float currentTime = 0f;
            while (currentTime < hideDuration)
            {
                currentTime += Time.deltaTime;
                canvasGroup.alpha = 1 - currentTime / hideDuration;
                yield return null;
            }
        }
    }
}
