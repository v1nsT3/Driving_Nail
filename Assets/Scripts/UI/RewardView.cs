using TMPro;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RewardView : MonoBehaviour
{
    [SerializeField] private PlayerReward _playerReward;
    [SerializeField] private TMP_Text _seriesName;
    [SerializeField] private TMP_Text _multiplier;
    [SerializeField] private TMP_Text _coins;

    private Animator _animator;
    private int _enterTrigger = Animator.StringToHash("Enter");

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _playerReward.SeriesChanged += OnSeriesChanged;
    }

    private void OnDisable()
    {
        _playerReward.SeriesChanged -= OnSeriesChanged;
    }

    private void OnSeriesChanged(Series series)
    {
        _animator.SetTrigger(_enterTrigger);
        _seriesName.text = series.Name;
        _multiplier.text = series.Multiplier > 1 ? "x" + series.Multiplier.ToString() : "";
        _coins.text = "+" + series.CoinsAmmount.ToString();
    }
}
