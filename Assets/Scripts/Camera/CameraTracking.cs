using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Camera))]
public class CameraTracking : MonoBehaviour
{
    [SerializeField] private float _durationMove;
    [SerializeField] private float _durationRotate;

    private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    public void SetTarget(Transform targetPoint)
    {
        transform.DOMove(targetPoint.position, _durationMove);
        transform.DORotateQuaternion(targetPoint.rotation, _durationRotate);
    }
}
