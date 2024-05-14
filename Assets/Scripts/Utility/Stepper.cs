using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace CodeSample_Currencies.Utility
{
    public class Stepper : MonoBehaviour
    {
        [SerializeField] TMP_Text textValue;
        [SerializeField] int defaultValue = 1;
        [SerializeField] int minValue = 1;
        [SerializeField] int maxValue = 3;
        [SerializeField] UnityEvent onValueChanged;

        private int value;
        public int Value
        {
            get => value;
            set
            {
                if (value < minValue || value > maxValue)
                    return;
                this.value = value;
                textValue.text = value.ToString();
                onValueChanged?.Invoke();
            }
        }

        private void Awake()
        {
            value = defaultValue;
        }

        // Called from Button - Left
        public void OnLeftPressed()
        {
            Value--;
        }

        // Called from Button - Right
        public void OnRightPressed()
        {
            Value++;
        }
    }
}
