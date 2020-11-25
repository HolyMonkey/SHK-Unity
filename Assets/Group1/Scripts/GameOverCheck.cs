using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCheck : MonoBehaviour
{
    [SerializeField] private GameObject _screen;
    [SerializeField] private EnemySpawner _enemySpawner;

    private void OnEnable()
    {
        _enemySpawner.AllEnemiesLeft += ShowGameOverScreen;
    }

    private void OnDsable()
    {
        _enemySpawner.AllEnemiesLeft -= ShowGameOverScreen;
    }

    private void ShowGameOverScreen()
    {
        _screen.SetActive(true);
    }
}
