using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private Game _game;

    private void OnEnable()
    {
        _game.AllEnemiesDead += OnAllEnemiesDead;
    }

    private void OnDisable()
    {
        _game.AllEnemiesDead -= OnAllEnemiesDead;
    }

    private void OnAllEnemiesDead()
    {
        _gameOverScreen.SetActive(true);
    }
}
