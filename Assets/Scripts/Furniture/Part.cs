using UnityEngine;
using DG.Tweening;
using System.Collections;

public class Part : MonoBehaviour
{
    private float _durationMove = 0.7f;
    private Tween _tween;

    public bool IsMove => _tween.IsActive();

    private void OnEnable()
    {
        StartCoroutine(MoveDelya());
    }

    private IEnumerator MoveDelya()
    {
        yield return new WaitForSeconds(1f);
        _tween = transform.DOLocalMove(Vector3.zero, _durationMove);
    }
}
