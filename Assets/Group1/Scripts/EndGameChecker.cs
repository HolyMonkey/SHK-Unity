using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class EndGameChecker : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;

    [SerializeField] private PlayerController _player;

    public event Action AllEnemiesDied;

    private void OnEnable()
    {
        _player.EnemyDied += OnEnemyDied;
    }

    private void OnDisable()
    {
        _player.EnemyDied -= OnEnemyDied;
    }

    private void Start()
    {
        _enemies = FindObjectsOfType<Enemy>().ToList();
    }

    private void OnEnemyDied(Enemy enemy)
    {
        _enemies.Remove(enemy);
        AllEnemiesDied?.Invoke();
    }
}
