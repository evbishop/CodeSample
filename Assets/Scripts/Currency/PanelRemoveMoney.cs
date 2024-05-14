using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CodeSample_Currencies.Currency
{
    public class PanelRemoveMoney : MonoBehaviour
    {
        [SerializeField] TMP_InputField inputFieldCopperCoinsToRemove;
        [SerializeField] TMP_InputField inputFieldSilverCoinsToRemove;
        [SerializeField] TMP_InputField inputFieldGoldCoinsToRemove;

        // Called from Button - Remove Coins
        public void RemoveCoins()
        {
            Dictionary<CurrencyType, int> currenciesToRemove = new();
            if (inputFieldCopperCoinsToRemove.text != string.Empty)
                currenciesToRemove.Add(CurrencyType.Copper, int.Parse(inputFieldCopperCoinsToRemove.text));
            if (inputFieldSilverCoinsToRemove.text != string.Empty)
                currenciesToRemove.Add(CurrencyType.Silver, int.Parse(inputFieldSilverCoinsToRemove.text));
            if (inputFieldGoldCoinsToRemove.text != string.Empty)
                currenciesToRemove.Add(CurrencyType.Gold, int.Parse(inputFieldGoldCoinsToRemove.text));

            if (!CurrencyHandler.Instance.TryRemoveCurrencies(currenciesToRemove))
                Debug.Log("Not enough money");
        }
    }
}
