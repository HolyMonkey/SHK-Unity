using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnemyMover))]
public class Enemy : MonoBehaviour
{
    private LevelFinisher _levelFinisher;

    public void Init(LevelFinisher levelFinisher)
    {
        _levelFinisher = levelFinisher;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _levelFinisher.AddKilledEnemy(this);

            gameObject.SetActive(false);
        }
    }
}
