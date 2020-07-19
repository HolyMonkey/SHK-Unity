using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverChecker: MonoBehaviour
{
    [SerializeField] private GameObject _blackScreen;
    [SerializeField] private Player _player;
    [SerializeField] private List<Enemy> _enemies;

    private void OnEnable()
    {
        for (int i = 0; i < _enemies.Count; i++)
        {
            _enemies[i].Dead += OnEnemyDestroy;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _enemies.Count; i++)
        {
            _enemies[i].Dead -= OnEnemyDestroy;
        }
    }

    private void OnEnemyDestroy(Enemy enemy)
    {
        enemy.Dead -= OnEnemyDestroy;
        _enemies.Remove(enemy);
        if (_enemies.Count == 0)
        {
            _player.enabled = false;
            ShowBlackScreen();
        }
    }

    private void ShowBlackScreen()
    {
        _blackScreen.SetActive(true);
    }
}
