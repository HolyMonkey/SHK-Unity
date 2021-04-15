using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private GameObject _blackWindow;

    private void Start()
    {
        Time.timeScale = 1;
        _spawner.StopGame += OnStopGame;
        _blackWindow.SetActive(false);
    }

    private void OnDisable()
    {
        _spawner.StopGame -= OnStopGame;
    }

    private void OnStopGame()
    {
        _blackWindow.SetActive(true);
        Time.timeScale = 0;
    }
}
