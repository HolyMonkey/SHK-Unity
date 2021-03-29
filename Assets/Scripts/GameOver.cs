using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private GameObject _gameOverPanel;

    private void OnEnable()
    {
        _spawner.AllEnemiesDied += OnAllEnemiesDied;
    }

    private void OnDisable()
    {
        _spawner.AllEnemiesDied -= OnAllEnemiesDied;
    }

    private void OnAllEnemiesDied()
    {
        _gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
