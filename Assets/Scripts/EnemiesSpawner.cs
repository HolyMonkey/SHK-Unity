using System;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    private int _enemiesCount;
    private Transform _player;

    [SerializeField] private Transform[] _spawnPositions;
    [SerializeField] private GameObject _enemyTemplate;
    [SerializeField] private Transform _parent;
    [SerializeField] private PlayerSpawner _playerSpawner;

    public event Action<EnemyHealth> OnEnemyDied;
    public event Action OnAllEnemiesDied;
    
    public void Init()
    {
        _enemiesCount = _spawnPositions.Length;
        _playerSpawner.OnPlayerSpawned += OnPlayerSpawned;
    }

    private void OnPlayerSpawned(Transform player)
    {
        _player = player;
        _playerSpawner.OnPlayerSpawned -= OnPlayerSpawned;
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < _spawnPositions.Length; i++)
        {
            GameObject enemy = Instantiate(_enemyTemplate, _spawnPositions[i].position, Quaternion.identity, _parent);
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            enemyHealth.OnDied += OnDied;
            EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
            enemyMovement.Init(_player);
        }
    }

    private void OnDied(EnemyHealth enemyHealth)
    {
        enemyHealth.OnDied -= OnDied;
        _enemiesCount--;
        OnEnemyDied?.Invoke(enemyHealth);
        if (_enemiesCount == 0)
        {
            OnAllEnemiesDied?.Invoke();
        }
    }
}
