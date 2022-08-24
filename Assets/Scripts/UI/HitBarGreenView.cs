using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HitBarGreenView : MonoBehaviour
{
    [SerializeField] private Color _color;
    [SerializeField] private Image _background;

    private float _durationFade = 0.5f;

    public void Fade()
    {
        _background.color = _color;
        _background.DOFade(0, _durationFade);
    }
}
