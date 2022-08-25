using UnityEngine;
using UnityEngine.Events;

public class PlayerWallet : MonoBehaviour
{
    private int _coins;

    public int Coins => _coins;

    public event UnityAction<int> CoinsChanged;

    public void AddCoins(int coins)
    {
        _coins += coins;
        CoinsChanged?.Invoke(_coins);
    }

    public void DecreaseCoins(int coins)
    {
        _coins -= coins;
        CoinsChanged?.Invoke(_coins);
    }
}
