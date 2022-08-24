using UnityEngine;

[System.Serializable]
public class Manual 
{
    [SerializeField] private Part _part;
    [SerializeField] private Transform _cameraPoint;
    [SerializeField] private Nail _nail;

    public Part Part => _part;
    public Transform CameraPoint => _cameraPoint;
    public Nail Nail => _nail;
}
