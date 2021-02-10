using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private GameObject _enemyTemplate;
    [SerializeField] private GameObject _speedBoosterTemplate;
    [SerializeField] private int _enemyCount;
    [SerializeField] private int _speedBoosterCount;
    [SerializeField] private int _spawnRadius;

    private int _enemySpawned;
    private int _enemyLeft;

    private void Start()
    {
        for (int i = 0; i < _speedBoosterCount; i++)
        {
            SpawnObject(_speedBoosterTemplate);
        }

        for (int i = 0; i < _enemyCount; i++)
        {
            SpawnObject(_enemyTemplate);
        }

        _enemyLeft = _enemySpawned;
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.EnemyDying -= OnEnemyDying;
        _enemyLeft--;

        if (_enemyLeft == 0)
            _gameOverScreen.gameObject.SetActive(true);
    }

    private void SpawnObject(GameObject template)
    {
        var spawned = Instantiate(template, Random.insideUnitCircle * _spawnRadius, Quaternion.identity);

        if (spawned.TryGetComponent(out Enemy enemy))
        {
            enemy.EnemyDying += OnEnemyDying;
            _enemySpawned++;
        }
    }
}
