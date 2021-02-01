using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private Enemy _template;
    [SerializeField] private int _enemyCount;
    [SerializeField] private int _spawnRadius;

    private int _enemySpawned;
    private int _enemyLeft;

    private void Start()
    {
        for (int i = 0; i < _enemyCount; i++)
        {
            Enemy spawned = Instantiate(_template, Random.insideUnitCircle * _spawnRadius, Quaternion.identity);
            spawned.EnemyDying += OnEnemyDying;
            _enemySpawned++;
        }

        _enemyLeft = _enemySpawned;
    }

    public void OnEnemyDying(Enemy enemy)
    {
        enemy.EnemyDying -= OnEnemyDying;
        _enemyLeft--;

        if (_enemyLeft == 0)
            _gameOverScreen.gameObject.SetActive(true);
    }
}
