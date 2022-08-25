using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject() == true)
            return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
            _player.StartMove();
        else if (Input.GetKeyUp(KeyCode.Mouse0))
            _player.StopMove();
    }
}
