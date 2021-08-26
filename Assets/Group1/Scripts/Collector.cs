using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collector : MonoBehaviour
{
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private List<Booster> _boosters;

    private int _diedEnemies;

    public event UnityAction AllEnemyDied;

    private void OnEnable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Died += OnDied;
        }
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Died -= OnDied;
        }
    }

    private void Update()
    {
        DestroyEnemy();

        CollectBooster();
    }

    private void DestroyEnemy()
    {
        foreach (var enemy in _enemies)
            CallByRange(enemy, () => enemy.Die());
    }

    private void CollectBooster()
    {
        foreach (var booster in _boosters)
            CallByRange(booster, () => _playerMover.IncreaseSpeed());
    }

    private void CallByRange(CollectedObjects collectedObjects, Action callback)
    {
        if (Vector3.Distance(_player.transform.position, collectedObjects.transform.position) < collectedObjects.Range)
                callback?.Invoke();
    }

    private void OnDied()
    {
        _diedEnemies++;

        if (_diedEnemies >= _enemies.Count)
            AllEnemyDied?.Invoke();
    }
}
