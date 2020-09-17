using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private List<Enemy> _enemies;

    public UnityAction AllEnemiesDead;

    private void Start()
    {
        CheckExistenceOfEnemies();

        foreach (var enemy in _enemies)
        {
            enemy.Init(_player);
        }
    }

    private void OnEnable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.EnemyDead += OnEnemyDied;
        }
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.EnemyDead -= OnEnemyDied;
        }
    }

    private void OnEnemyDied(Enemy enemy)
    {
        enemy.EnemyDead -= OnEnemyDied;
        _enemies.Remove(enemy);

        CheckExistenceOfEnemies();
    }

    private void CheckExistenceOfEnemies()
    {
        if (_enemies.Count == 0)
        {
            AllEnemiesDead?.Invoke();
        }
    }
}
