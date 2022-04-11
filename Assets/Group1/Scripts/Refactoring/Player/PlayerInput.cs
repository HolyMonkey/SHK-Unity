using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMover _playerMover;

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
            _playerMover.Move(Vector3.up);

        if (Input.GetKey(KeyCode.S))
            _playerMover.Move(Vector3.down);

        if (Input.GetKey(KeyCode.A))
            _playerMover.Move(Vector3.left);

        if (Input.GetKey(KeyCode.D))
            _playerMover.Move(Vector3.right);
    }
}
