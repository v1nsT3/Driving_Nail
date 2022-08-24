using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Furniture _furniture;
    [SerializeField] private CameraTracking _cameraTracking;

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
    }
}
