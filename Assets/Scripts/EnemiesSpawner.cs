using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPositions;
    [SerializeField] private GameObject _enemyTemplate;
    [SerializeField] private Transform _parent;
    [SerializeField] private PlayerSpawner _playerSpawner;

    private List<GameObject> _enemies;
    private int _enemiesCount;

    public List<GameObject> Enemies => _enemies;
    public event Action<EnemyHealth> EnemyDied;
    public event Action AllEnemiesDied;
    
    public void Init()
    {
        _enemies = new List<GameObject>();
        _enemiesCount = _spawnPositions.Length;
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < _spawnPositions.Length; i++)
        {
            GameObject enemy = Instantiate(_enemyTemplate, _spawnPositions[i].position, Quaternion.identity, _parent);
            _enemies.Add(enemy);
            if(enemy.TryGetComponent(out EnemyHealth enemyHealth))
                enemyHealth.Died += Died;
            else
                throw new ArgumentNullException("EnemyHealth");
        }
    }

    private void Died(EnemyHealth enemyHealth)
    {
        _enemiesCount--;
        enemyHealth.Died -= Died;
        _enemies.Remove(enemyHealth.gameObject);
        EnemyDied?.Invoke(enemyHealth);

        if (_enemiesCount == 0)
        {
            AllEnemiesDied?.Invoke();
        }
    }
}
