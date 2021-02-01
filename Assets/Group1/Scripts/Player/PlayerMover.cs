using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Player))]
public class PlayerMover : MonoBehaviour
{
    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
            Move(Vector3.up);

        if (Input.GetKey(KeyCode.S))
            Move(Vector3.down);

        if (Input.GetKey(KeyCode.A))
            Move(Vector3.left);

        if (Input.GetKey(KeyCode.D))
            Move(Vector3.right);
    }

    private void Move(Vector3 direction)
    {
        transform.position += direction * _player.Speed * Time.deltaTime;
    }
}
