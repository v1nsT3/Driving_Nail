using UnityEngine;
using DG.Tweening;

public class Part : MonoBehaviour
{
    private float _durationMove = 1.5f;

    private void OnEnable()
    {
        transform.DOLocalMove(Vector3.zero, _durationMove);
    }
}
