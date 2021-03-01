using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMover : MonoBehaviour
{
    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    public void Move(Vector3 direction)
    {
        transform.position += direction * _player.CurrentSpeed * Time.deltaTime;
    }
}
