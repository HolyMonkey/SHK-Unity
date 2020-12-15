using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private Player _player;

    private List<Enemy> _enemies = new List<Enemy>();

    private void Start()
    {
        _gameOverScreen.SetActive(false);

        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach(Enemy enemy in enemies)
        {
            _enemies.Add(enemy);
        }
    }

    private void CheckEndGame(Enemy enemy)
    {
        _enemies.Remove(enemy);
        if (_enemies.Count.Equals(0))
        {
            Time.timeScale = 0;
            _gameOverScreen.SetActive(true);
        }
    }

    private void OnEnable()
    {
        _player.DestroiedEnemy += CheckEndGame;
    }

    private void OnDisable()
    {
        _player.DestroiedEnemy -= CheckEndGame;
    }
}
