using UnityEngine;

public class TargetSetter : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Furniture _furniture;
    [SerializeField] private CameraTracking _cameraTracking;
    [SerializeField] private PlayerHitHandler _playerHitHandler;

    private void OnEnable()
    {
        _furniture.ManualChanged += OnManualChanged;
    }

    private void OnDisable()
    {
        _furniture.ManualChanged -= OnManualChanged;
    }

    private void OnManualChanged(Manual manual)
    {
        _cameraTracking.SetTarget(manual.CameraPoint);
        _player.SetTarget(manual.Nail.HatPoint);
        _playerHitHandler.SetNail(manual.Nail);
    }
}
