using UnityEngine;
using DG.Tweening;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _hand;
    [SerializeField] private float _maxOffsetAxisY;
    [SerializeField] private float _durationMoveDown;
    [SerializeField] private float _durationMoveUp;

    private Transform _targetPoint;
    private Coroutine _currentCoroutine;
    private Sequence _sequence;
    private bool _isMove = false;
    private Quaternion _startHandRotation;

    private void Start()
    {
        _startHandRotation = _hand.localRotation;
    }

    private void Update()
    {
        if (_targetPoint != null)
            transform.position = _targetPoint.position;
    }

    public void SetTarget(Transform targetPoint)
    {
        _targetPoint = targetPoint;
        transform.rotation = Quaternion.LookRotation(-targetPoint.forward);
    }

    public void StartMove()
    {
        _isMove = true;

        if (_currentCoroutine == null)
            _currentCoroutine = StartCoroutine(MoveDelay());
    }

    public void StopMove()
    {
        _isMove = false;
    }

    private IEnumerator MoveDelay()
    {
        float hitValue = 0;
        
        while (hitValue <= 1 && _isMove == true)
        {
            hitValue += Time.deltaTime;
            _hand.localRotation = Quaternion.Lerp(_startHandRotation, _startHandRotation * Quaternion.Euler(0, _maxOffsetAxisY, 0), hitValue);
            yield return null;
        }

        _sequence = DOTween.Sequence();
        _sequence.Append(_hand.DOLocalRotateQuaternion(_startHandRotation * Quaternion.Euler(0, -_maxOffsetAxisY, 0), _durationMoveDown));
        _sequence.Append(_hand.DOLocalRotateQuaternion(_startHandRotation, _durationMoveUp));

        hitValue = 0;

        _currentCoroutine = null;
    }
}
