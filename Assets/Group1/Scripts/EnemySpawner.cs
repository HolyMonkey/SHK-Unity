using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _enemiesCount;
    [SerializeField] private float _spawnRaius;
    public UnityAction AllEnemiesDied;

    private void Start()
    {
        for (int i = 0; i < _enemiesCount; i++)
        {
            Vector2 enemyPosition = Random.insideUnitCircle * _spawnRaius;
            var enemy = Instantiate(_enemy, enemyPosition, Quaternion.identity,transform);
            enemy.Dead += OnEnemyDie;
        }
    }

    private void OnEnemyDie(Enemy enemy)
    {
        _enemiesCount--;
        Unsubscribe(enemy);
    }

    private void Unsubscribe(Enemy enemy)
    {
        enemy.Dead -= OnEnemyDie;
        if (_enemiesCount == 0)
        {
            AllEnemiesDied?.Invoke();
        }
    }
}
