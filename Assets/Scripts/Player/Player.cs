using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    private Transform _targetPoint;

    public void SetTarget(Transform targetPoint)
    {
        transform.rotation = Quaternion.LookRotation(-targetPoint.forward);
    }

    private void Update()
    {
        if (_targetPoint != null)
            transform.position = _targetPoint.position;
    }
}
