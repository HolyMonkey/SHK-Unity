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

    private int _numberOfSpawnedEnemy;
    private int _numberOfKilledEnemy;

    private void Start()
    {
        SpawnObjects(_speedBoosterTemplate, _speedBoosterCount);
        SpawnObjects(_enemyTemplate, _enemyCount);
    }

    private void OnEnemyDied(Enemy enemy)
    {
        enemy.EnemyDied -= OnEnemyDied;
        _numberOfKilledEnemy++;

        if (_numberOfKilledEnemy == _numberOfSpawnedEnemy)
            _gameOverScreen.gameObject.SetActive(true);
    }

    private void SpawnObjects(GameObject template, int count)
    {
        for (int i = 0; i < count; i++)
        {
            var spawned = Instantiate(template, Random.insideUnitCircle * _spawnRadius, Quaternion.identity);

            if (spawned.TryGetComponent(out Enemy enemy))
            {
                enemy.EnemyDied += OnEnemyDied;
                _numberOfSpawnedEnemy++;
            }
        }
    }
}
