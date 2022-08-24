using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HitBarView : MonoBehaviour
{
    [SerializeField] private Accuracy _accuracy;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private HitBarGreenView _hitBarGreenView;
    [SerializeField] private Player _player;
    [SerializeField] private Slider _slider;

    private float _durationFade = 0.5f;

    private void OnEnable()
    {
        _player.StartedMove += OnPlayerStartedMove;
        _player.StoppedMove += OnPlayerStoppedMove;
        _player.PositionChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _player.StartedMove -= OnPlayerStartedMove;
        _player.StoppedMove -= OnPlayerStoppedMove;
        _player.PositionChanged -= OnValueChanged;
    }

    private void OnPlayerStartedMove()
    {
        _canvasGroup.alpha = 1;
    }

    private void OnPlayerStoppedMove(float hitValue)
    {
        if (_accuracy.HitValueIsRange(hitValue))
        {
            _hitBarGreenView.Fade();
            _canvasGroup.alpha = 0;
        }
        else
        {
            _canvasGroup.DOFade(0, _durationFade);
        }

    }

    private void OnValueChanged(float value)
    {
        _slider.value = value;
    }
}
