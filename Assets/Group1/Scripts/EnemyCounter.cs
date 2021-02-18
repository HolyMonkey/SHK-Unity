using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private List<Enemy> _enemies;

    private void OnEnable()
    {
        foreach (Enemy enemy in _enemies)
            enemy.Died += OnEnemyDied;
    }

    private void OnDisable()
    {
        foreach (Enemy enemy in _enemies)
            enemy.Died -= OnEnemyDied;
    }

    private void OnEnemyDied(Enemy enemy)
    {
        _enemies.Remove(enemy);
        if (_enemies.Count == 0)
            FinishGame();
    }

    private void FinishGame()
    {
        _gameOverScreen.SetActive(true);
    }
}
