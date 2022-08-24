using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerWallet))]
public class PlayerReward : MonoBehaviour
{
    [SerializeField] private List<Series> _series = new List<Series>();

    private PlayerWallet _playerWallet;
    private int _currentSeriesIndex;

    public event UnityAction<Series> SeriesChanged;

    private void Start()
    {
        _playerWallet = GetComponent<PlayerWallet>();
    }

    public void SetSeriesForGreatHit()
    {
        if (++_currentSeriesIndex > _series.Count - 1)
            _currentSeriesIndex = 0;

        _currentSeriesIndex++;

        SetSeries(_currentSeriesIndex);
    }

    public void SetSeiresForGoodHit()
    {
        _currentSeriesIndex = 0;
        SetSeries(_currentSeriesIndex);
    }

    private void SetSeries(int index)
    {
        Series series = _series[index];
        _playerWallet.AddCoins(series.CoinsAmmount * series.Multiplier);
        SeriesChanged?.Invoke(series);
    }
}
