using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector2 _move;
    private PlayerInput _input;

    private void Start()
    {
        _input = new PlayerInput();
        _input.Enable();
    }

    private void Update()
    {
        _move = _input.PlayerControl.Move.ReadValue<Vector2>();
        OnMove(_move);
    }

    private void OnMove(Vector2 move)
    {
        transform.position += new Vector3(move.x, move.y, 0) *_speed * Time.deltaTime;
    }
}
