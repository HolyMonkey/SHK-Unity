using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProcess : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private Player _player;

    private void Start()
    {
        _gameOverScreen.SetActive(false);
    }

    private void ControlEndGame()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        if (enemies.Length.Equals(1))
        {
            Time.timeScale = 0;
            _gameOverScreen.SetActive(true);
        }
    }

    private void OnEnable()
    {
        _player.DestroiedEnemy += ControlEndGame;
    }

    private void OnDisable()
    {
        _player.DestroiedEnemy -= ControlEndGame;
    }
}
