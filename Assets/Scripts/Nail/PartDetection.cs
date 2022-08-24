using UnityEngine;
using UnityEngine.Events;

public class PartDetection : MonoBehaviour
{
    public event UnityAction Detected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Part part))
        {
            if (part.IsMove == false)
            {
                Detected?.Invoke();
            }
        }
    }
}
