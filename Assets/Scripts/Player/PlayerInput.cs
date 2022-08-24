using UnityEngine;

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
        if (Input.GetKeyDown(KeyCode.Mouse0))
            _player.StartMove();
        else if (Input.GetKeyUp(KeyCode.Mouse0))
            _player.StopMove();
    }
}
