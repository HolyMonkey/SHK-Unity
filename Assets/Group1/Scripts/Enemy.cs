using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnemyMover))]
public class Enemy : MonoBehaviour
{
    public event OnDied Died;

    public delegate void OnDied(Enemy sender);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            Died?.Invoke(this);

            Destroy(gameObject);
        }
    }
}
