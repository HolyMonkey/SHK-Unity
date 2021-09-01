using System.Collections.Generic;
using UnityEngine;

public class EnemiesPoolWatcher : MonoBehaviour
{
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private PlayerObjectInteraction _player;
    [SerializeField] private List<Enemy> _enemies = new List<Enemy>();

    private void OnEnable()
    {
        _player.EnemyCollided += OnInteractWithObject;
    }

    private void OnDisable()
    {
        _player.EnemyCollided -= OnInteractWithObject;
    }

    private void OnInteractWithObject(Enemy enemy)
    {
        _enemies.Remove(enemy);

        TryEnableEndScreen();
    }

    private void TryEnableEndScreen()
    {
        if (_enemies.Count == 0)
        {
            _endScreen.SetActive(true);

            Time.timeScale = 0;
        }
    }
}
