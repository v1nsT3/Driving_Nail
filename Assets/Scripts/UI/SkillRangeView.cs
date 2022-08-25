using UnityEngine;
using DG.Tweening;

public abstract class SkillRangeView : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private float _durationChangeSize;

    private float _multiplier = 10f;

    protected void OnRangeChanged(float value)
    {
        _rectTransform.DOSizeDelta(new Vector2(value * _multiplier, _rectTransform.sizeDelta.y), _durationChangeSize);
    }
}
