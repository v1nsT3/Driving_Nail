using UnityEngine;

public class Nail : MonoBehaviour
{
    [SerializeField] private Transform _hat;

    public Transform HatPoint => _hat;
}
