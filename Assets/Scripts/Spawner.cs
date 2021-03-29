using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyTemplate;
    [SerializeField] private GameObject _boosterTemplate;
    [SerializeField] private int _enemiesCount;
    [SerializeField] private int _boostersCount;
    [SerializeField] private float _spawnRadius;

    private int _deadEnemiesCount;

    public event UnityAction AllEnemiesDied;

    private void Start()
    {
        Spawn(_enemyTemplate, _enemiesCount);
        Spawn(_boosterTemplate, _boostersCount);
    }

    private void Spawn(GameObject template, int count)
    {
        for (int i = 0; i < count; i++)
        {
            var spawned = Instantiate(template, Random.insideUnitCircle * _spawnRadius, Quaternion.identity);

            if (spawned.TryGetComponent(out Enemy enemy))
            {
                enemy.Died += OnEnemyDied;
            }
        }
    }

    private void OnEnemyDied(Enemy enemy)
    {
        enemy.Died -= OnEnemyDied;
        _deadEnemiesCount++;

        if (_deadEnemiesCount == _enemiesCount)
        {
            AllEnemiesDied?.Invoke();
        }
    }
}
