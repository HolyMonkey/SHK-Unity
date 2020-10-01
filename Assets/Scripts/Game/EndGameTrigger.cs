﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class EndGameTrigger : MonoBehaviour
{
    private Enemy[] _enemies;

    public event UnityAction GameEnded;

    private void Start()
    {
        _enemies = FindObjectsOfType<Enemy>();
        foreach (var enemy in _enemies)
        {
            enemy.CollisionWithPlayer += TryEndGameTrigger;
        }
    }

    private void TryEndGameTrigger()
    {
        int liveEnemies = _enemies.Count(p => p.isActiveAndEnabled == true);
        if (liveEnemies == 0)
        {
            GameEnded?.Invoke();
        }
    }
}