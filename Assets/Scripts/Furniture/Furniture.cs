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

    private void OnNailHummered(Nail nail)
    {
        nail.Hammered -= OnNailHummered;
        nail.Broken -= OnNailBroken;

        NextManual();
    }

    private void OnNailBroken(Nail nail)
    {
        nail.Hammered -= OnNailHummered;
        nail.Broken -= OnNailBroken;
        nail.gameObject.SetActive(false);
        StartCoroutine(RestartNailDelay());
    }

    private IEnumerator RestartNailDelay()
    {
        yield return new WaitForSeconds(0.5f);
        SetManual(_currentManualIndex);
    }

    private void NextManual()
    {
        _currentManualIndex++;
        SetManual(_currentManualIndex);
    }

    private void SetManual(int index)
    {
        Manual manual = _manuals[_currentManualIndex];
        manual.Part.gameObject.SetActive(true);
        manual.Nail.gameObject.SetActive(true);
        manual.Nail.Broken += OnNailBroken;
        manual.Nail.Hammered += OnNailHummered;
        ManualChanged?.Invoke(manual);
    }
}
