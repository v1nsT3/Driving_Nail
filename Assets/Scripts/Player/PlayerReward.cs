using UnityEngine;

[RequireComponent(typeof(PlayerWallet))]
public class PlayerReward : MonoBehaviour
{
    private PlayerWallet _playerWallet;
    private int _currentSeriesIndex;

    private void Start()
    {
        _playerWallet = GetComponent<PlayerWallet>();
    }

    public void SetSeriesForGreatHit()
    {

    }

    public void SetSeiresForGoodHit()
    {

    }
}
