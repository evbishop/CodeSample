using CodeSample_Currencies.Currency;

namespace CodeSample_Currencies.Utility
{
    public class GameSession : MonoSingleton<GameSession>
    {
        private void Awake()
        {
            if (TryInitializeSingleton())
            {
                CurrencyHelper.Instance.Init();
            }
        }
    }
}
