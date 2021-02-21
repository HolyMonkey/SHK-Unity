using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnemyMover))]
public class Enemy : MonoBehaviour
{
    public static Enemy Singleton { get; private set; }

    public event OnDeath DeathEvent;
    public delegate void OnDeath(Enemy enemy);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            DeathEvent?.Invoke(this);

            gameObject.SetActive(false);
        }
    }
}
