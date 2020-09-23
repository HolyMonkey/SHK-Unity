using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class EndGameTrigger : MonoBehaviour
{
    [SerializeField] private EnemiesPool _enemiesPool;

    private Enemy[] _enemies;

    public event UnityAction GameEnded;

    private void Start()
    {
        _enemies = _enemiesPool.GetEnemies();
        foreach (var enemy in _enemies)
        {
            enemy.CollisionWithPlayer += CallEndGameTrigger;
        }
    }

    private void CallEndGameTrigger()
    {
        int liveEnemies = _enemies.Count(p => p.isActiveAndEnabled == true);
        if (liveEnemies == 0)
        {
            GameEnded?.Invoke();
        }
    }
}