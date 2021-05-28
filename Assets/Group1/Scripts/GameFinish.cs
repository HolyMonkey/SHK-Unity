using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFinish : MonoBehaviour
{
    [SerializeField] private GameObject _blackWindow;
    private List<Enemy> _enemies = new List<Enemy>();

    private void Start()
    {
        Time.timeScale = 1;
        _blackWindow.SetActive(false);
        AddAliveEnemies();
    }

    private void AddAliveEnemies()
    {
        _enemies.AddRange(FindObjectsOfType<Enemy>());
        foreach (var enemy in _enemies)
        {
            enemy.Dying += OnEnemyDie;
        }
    }

    private void OnEnemyDie(Enemy enemy)
    {
        _enemies.Remove(enemy);
        Unsubscribe(enemy);
        CheckAliveEnemies();
    }

    private void Unsubscribe(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDie;
    }

    private void CheckAliveEnemies()
    {
        if (_enemies.Count == 0)
        {
            AllEnemiesDied();
        }
    }

    private void AllEnemiesDied()
    {
        Time.timeScale = 0;
        _blackWindow.SetActive(true);
    }
}
