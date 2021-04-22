using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFinish : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private GameObject _blackWindow;

    private void Start()
    {
        Time.timeScale = 1;
        _blackWindow.SetActive(false);
    }

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
        Time.timeScale = 0;
        _blackWindow.SetActive(true);
    }
}
