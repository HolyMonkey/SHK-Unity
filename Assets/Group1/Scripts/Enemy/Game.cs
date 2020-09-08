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
        CheckActiveEnemies();

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

    private void OnEnemyDied(Enemy enemy)
    {
        enemy.EnemyDead -= OnEnemyDied;
        _enemies.Remove(enemy);

        CheckActiveEnemies();
    }

    private void CheckActiveEnemies()
    {
        if (_enemies.Count == 0)
        {
            AllEnemiesDead?.Invoke();
        }
    }
}
