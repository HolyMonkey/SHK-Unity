using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int _enemyCount;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private UnityEvent _playerVictory;

    private List<Enemy> _enemies;
    private Vector3 _spawnPoint;

    private void Start()
    {
        _enemies = new List<Enemy>();

        for (int i = 0; i < _enemyCount; i++)
        {
            _spawnPoint = Random.insideUnitCircle * 5;
            _enemies.Add(Instantiate(_enemyPrefab, _spawnPoint, Quaternion.identity));
            _enemies[i].Init(transform);
        }
    }

    public void SubtractEnemy()
    {
        _enemyCount--;

        if (_enemyCount == 0)
        {
            _playerVictory.Invoke();
        }
    }
}