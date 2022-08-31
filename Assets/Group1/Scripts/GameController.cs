using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    private Enemy[] _enemies;
    private int _numberEnemies = 0;

    public static event Action EndGame;

    private void Start()
    {
        _enemies = gameObject.GetComponentsInChildren<Enemy>();
    }

    private void Awake()
    {
        Player.EnemyDefeated.AddListener(TryEnd);
    }

    private void TryEnd()
    {
        _numberEnemies++;
        if (_numberEnemies == _enemies.Length)
            EndGame?.Invoke();
    }
}

