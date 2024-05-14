using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeSample_Currencies.Currency
{
    public class PanelCurrency : MonoBehaviour
    {
        [SerializeField] CurrencyType currencyType;
        [SerializeField] Image currencyImage;
        [SerializeField] TMP_Text currencyText;
        [SerializeField] float animationDuration = 1f;
        [SerializeField] float animationScaleTo = 1.2f;
        [SerializeField] Color animationColorTo = Color.white;

        Tween tweenColor;
        Tween tweenScale;

        void Start()
        {
            currencyImage.sprite = CurrencyHelper.Instance.GetInfo(currencyType).Sprite;
            CurrencyHandler.Instance.OnWalletUpdated += HandleCurrencyUpdated;
        }

        private void OnDisable()
        {
            if (tweenColor != null)
            {
                tweenColor.Kill();
                tweenColor = null;
            }
            if (tweenScale != null)
            {
                tweenScale.Kill();
                tweenScale = null;
            }
        }

        void OnDestroy()
        {
            if (CurrencyHandler.Instance != null)
                CurrencyHandler.Instance.OnWalletUpdated -= HandleCurrencyUpdated;
        }

        void PlayAnimation()
        {
            if (tweenColor == null)
            {
                tweenColor = currencyText
                    .DOColor(animationColorTo, animationDuration)
                    .SetEase(Ease.InOutBack)
                    .SetLoops(2, LoopType.Yoyo)
                    .OnComplete(() =>
                    {
                        tweenColor.Kill();
                        tweenColor = null;
                    });
            }
            else
            {
                tweenColor.Restart();
                tweenColor.Play();
            }
            if (tweenScale == null)
            {
                tweenScale = currencyText.transform
                    .DOScale(animationScaleTo, animationDuration)
                    .SetEase(Ease.InOutBack)
                    .SetLoops(2, LoopType.Yoyo)
                    .OnComplete(() =>
                    {
                        tweenScale.Kill();
                        tweenScale = null;
                    });
            }
            else
            {
                tweenScale.Restart();
                tweenScale.Play();
            }
        }

        void HandleCurrencyUpdated(CurrencyType currencyType, int newQuantity, bool animateChange)
        {
            if (currencyType != this.currencyType)
                return;

            currencyText.text = $"x{newQuantity}";
            if (animateChange)
                PlayAnimation();
        }
    }
}
