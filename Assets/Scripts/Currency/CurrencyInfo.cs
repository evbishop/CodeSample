using UnityEngine;

namespace CodeSample_Currencies.Currency
{
    [CreateAssetMenu(fileName = "Currency", menuName = "Scriptable Objects/Currency")]
    public class CurrencyInfo : ScriptableObject
    {
        [field: SerializeField] public Sprite Sprite { get; private set; }

        [field: SerializeField] public CurrencyType CurrencyType { get; private set; }

        [SerializeField] private string localizationKey;
        public string Name => localizationKey;  // since this is a sample project,
                                                // I will just be using this key
                                                // as the name of the currency to display,
                                                // without passing it to any localization system

        [field: SerializeField] public int Worth { get; private set; }
    }
}