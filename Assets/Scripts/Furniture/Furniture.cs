using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Furniture : MonoBehaviour
{
    [SerializeField] private List<Manual> _manuals = new List<Manual>();

    private int _currentManualIndex = 0;

    public event UnityAction<Manual> ManualChanged;

    private void Start()
    {
        SetManual(_currentManualIndex);
    }

    private void NextManual()
    {

    }

    private void SetManual(int index)
    {
        Manual manual = _manuals[_currentManualIndex];
        ManualChanged?.Invoke(manual);
    }
}
