using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private Player _player;

    private List<Enemy> _enemies = new List<Enemy>();

    private void Start()
    {
        _gameOverScreen.SetActive(false);

        _enemies = FindObjectsOfType<Enemy>().ToList();
    }
    private void OnEnable()
    {
        _player.CheckEndGame += OnCheckEndGame;
    }

    private void OnDisable()
    {
        _player.CheckEndGame -= OnCheckEndGame;
    }
    private void OnCheckEndGame(Enemy enemy)
    {
        _enemies.Remove(enemy);
        if (_enemies.Count == 0)
        {
            Time.timeScale = 0;
            _gameOverScreen.SetActive(true);
        }
    }
}
