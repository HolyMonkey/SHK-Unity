using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinisher : MonoBehaviour
{
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private List<Enemy> _enemies = new List<Enemy>();

    void Start()
    {
        Time.timeScale = 1;
        _endScreen.SetActive(false);
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
        enemy.Dying -= OnEnemyDie;
        CheckAliveEnemies();
    }

    private void CheckAliveEnemies()
    {
        if (_enemies.Count == 0)
            ShowEndScreen();
    }

    public void ShowEndScreen()
    {
        Time.timeScale = 0;
        _endScreen.SetActive(true);
    }
}
