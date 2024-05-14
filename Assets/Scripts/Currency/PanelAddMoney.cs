using CodeSample_Currencies.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeSample_Currencies.Currency
{
    public class PanelAddMoney : MonoBehaviour
    {
        [SerializeField] TMP_InputField inputFieldMoneyToAdd;
        [SerializeField] TMP_Text textPlaceholderInputFieldMoneyToAdd;
        [SerializeField] Stepper stepperCurrenciesQuantity;
        [SerializeField] UIContainer containerCurrencySelection;
        [SerializeField] ToggleGroup toggleGroupCurrencyTypes;

        // Called from Button - Add Money
        public void AddMoney()
        {
            int money = 0;
            if (inputFieldMoneyToAdd.text != "")
                money = int.Parse(inputFieldMoneyToAdd.text);

            if (stepperCurrenciesQuantity.Value == 1)
            {
                if (toggleGroupCurrencyTypes.GetFirstActiveToggle().TryGetComponent<CurrencyTag>(
                    out var currencyTag))
                {
                    CurrencyHandler.Instance.AddCurrency(currencyTag.CurrencyType, money);
                }
                else
                {
                    Debug.LogError($"{toggleGroupCurrencyTypes.GetFirstActiveToggle().gameObject.name} is missing a CurrencyTag");
                }
            }
            else
            {
                CurrencyHandler.Instance.AddMoney(money, stepperCurrenciesQuantity.Value == 2);
            }
        }

        // Called from "Stepper - Currencies Quantity" onValueChanged callback
        public void HandleCurrenciesQuantityChanged()
        {
            if (stepperCurrenciesQuantity.Value == 1)
            {
                containerCurrencySelection.Show();
                inputFieldMoneyToAdd.text = string.Empty;
                textPlaceholderInputFieldMoneyToAdd.text = "Enter coins quantity";
            }
            else
            {
                containerCurrencySelection.Hide();
                inputFieldMoneyToAdd.text = string.Empty;
                textPlaceholderInputFieldMoneyToAdd.text = "Enter total money worth amount";
            }
        }
    }
}
