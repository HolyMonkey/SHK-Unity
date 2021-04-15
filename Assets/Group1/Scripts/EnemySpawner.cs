using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    public UnityAction StopGame;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _enemyCount;
    [SerializeField] private float _spawmRaius;

    private void Start()
    {
        for (int i = 0; i < _enemyCount; i++)
        {
            Vector2 enemyPosition = Random.insideUnitCircle * _spawmRaius;
            var enemy = Instantiate(_enemy, enemyPosition, Quaternion.identity,transform);
            enemy.GetComponent<Enemy>().DeadEnemy += OnEnemyDie;
        }
    }

    private void OnEnemyDie(Enemy enemy)
    {
        _enemyCount--;
        Unsubscribe(enemy);
    }

    private void Unsubscribe(Enemy enemy)
    {
        enemy.DeadEnemy -= OnEnemyDie;
        if (_enemyCount == 0)
        {
            StopGame?.Invoke();
        }
    }
}
