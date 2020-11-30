using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private int _enemyCount;
    [SerializeField] private float _spawnRadius;

    public event UnityAction<Enemy> EnemySpawned;

    private void Start()
    {
        for (int i = 0; i < _enemyCount; i++)
        {
            Enemy enemy = Instantiate(_enemyPrefab, Random.insideUnitCircle * _spawnRadius, Quaternion.identity);
            enemy.GetComponent<ObjectMover>().SetNewTargetPosition();
            EnemySpawned?.Invoke(enemy);
        }
    }
}
