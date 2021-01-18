using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private EnemyCounter _enemyCounter;

    private void Start()
    {
        _gameOverScreen.SetActive(false);

        _enemyCounter = FindObjectOfType<EnemyCounter>();
    }

    private void OnEnable()
    {
        _enemyCounter.GameOver += OnGameOver;
    }
    private void OnDisable()
    {
        _enemyCounter.GameOver -= OnGameOver;
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _gameOverScreen.SetActive(true);
    }
}
