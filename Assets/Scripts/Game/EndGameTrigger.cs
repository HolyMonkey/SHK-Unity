using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class EndGameTrigger : MonoBehaviour
{
    private Enemy[] _enemies;

    public event UnityAction GameEnded;

    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
        foreach (var enemy in _enemies)
        {
            enemy.CollisionWithPlayer += TryInvokeEndGameTrigger;
        }
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.CollisionWithPlayer -= TryInvokeEndGameTrigger;
        }
    }

    private void TryInvokeEndGameTrigger()
    {
        int liveEnemies = _enemies.Count(p => p.isActiveAndEnabled == true);
        if (liveEnemies == 0)
        {
            GameEnded?.Invoke();
        }
    }
}