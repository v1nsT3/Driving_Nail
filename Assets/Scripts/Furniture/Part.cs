using UnityEngine;
using DG.Tweening;

public class Part : MonoBehaviour
{
    private float _durationMove = 1.5f;
    private Tween _tween;

    public bool IsMove => _tween.IsActive();

    private void OnEnable()
    {
        _tween = transform.DOLocalMove(Vector3.zero, _durationMove);
    }
}
