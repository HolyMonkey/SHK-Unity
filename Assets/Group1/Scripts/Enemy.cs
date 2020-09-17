using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _detectDistance;

    private Player _player;

    public event UnityAction<Enemy> EnemyDead;

    private void Update()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) < _detectDistance)
        {
            Die();
        }
    }

    private void Die()
    {
        EnemyDead?.Invoke(this);

        Destroy(gameObject);
    }

    public void Init(Player player)
    {
        _player = player;
    }
}
