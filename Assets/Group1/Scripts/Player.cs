using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]

public class Player : MonoBehaviour
{
    private PlayerMover _playerMover;
    private const string Speed = "Speed";

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

    public void KillEnemy(Enemy enemy)
    {
        if (enemy.name == Speed)
            _playerMover.IncreaseSpeed();
            
        Destroy(enemy.gameObject);
    }
}
