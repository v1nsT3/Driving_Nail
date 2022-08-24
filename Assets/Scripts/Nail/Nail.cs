using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using System.Collections.Generic;
using System.Collections;
using System;

public class Nail : MonoBehaviour
{
    [SerializeField] private Transform _hat;
    [SerializeField] private MeshFilter _meshFilter;
    [SerializeField] private List<Mesh> _brokenMesh;

    private float _durationMove = 0.1f;
    private float _offsetMoveY = 0.07f;
    private Vector3 _startPosition;
    private Mesh _startMesh;
    private Coroutine _coroutine;
    private Tween _tween;
    private PartDetection _partDetection;

    public Transform HatPoint => _hat;

    public event UnityAction<Nail> Broken;
    public event UnityAction<Nail> Hammered;

    private void Awake()
    {
        _startMesh = _meshFilter.mesh;
        _startPosition = transform.position;
        _partDetection = GetComponentInChildren<PartDetection>();
    }

    private void OnEnable()
    {
        _meshFilter.mesh = _startMesh;
        transform.position = _startPosition;

        if(_partDetection == null)
        {
            gameObject.SetActive(false);
            throw new NullReferenceException();
        }

        _partDetection.Detected += OnHummerd;
    }

    private void OnDisable()
    {
        _partDetection.Detected -= OnHummerd;
    }

    public void Move()
    {
        _tween = transform.DOMoveY(transform.position.y - _offsetMoveY, _durationMove);
    }

    public void Break()
    {
        if (_coroutine == null)
        {
            _meshFilter.mesh = _brokenMesh[UnityEngine.Random.Range(0, _brokenMesh.Count)];
            _coroutine = StartCoroutine(BrokenDelay());
        }
    }

    private IEnumerator BrokenDelay()
    {
        yield return new WaitForSeconds(0.5f);
        _coroutine = null;
        Broken?.Invoke(this);
    }

    private void OnHummerd()
    {
        _tween.Kill();
        Hammered?.Invoke(this);
    }
}
