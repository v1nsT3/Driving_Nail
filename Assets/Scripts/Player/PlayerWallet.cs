using UnityEngine;
using UnityEngine.Events;

public class PlayerWallet : MonoBehaviour
{
    private int _coins;

    public event UnityAction CoinChanged;

    public void AddCoins(int coins)
    {
        _coins += coins;
        CoinChanged?.Invoke();
    }

    public void DecreaseCoins(int coins)
    {
        _coins -= coins;
        CoinChanged?.Invoke();
    }
}
