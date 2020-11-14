using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private float _spawnRadius;

    public event UnityAction<Enemy> EnemySpawned;

    private void Start()
    {
        for (int i = 0; i < _enemies.Length; i++)
        {
            Enemy enemy = Instantiate(_enemies[i], Random.insideUnitCircle * _spawnRadius, Quaternion.identity);
            EnemySpawned?.Invoke(enemy);
        }
    }
}
