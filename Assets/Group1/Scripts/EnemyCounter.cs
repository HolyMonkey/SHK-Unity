using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] private Player _player;

    public event UnityAction GameOver;

    private List<Enemy> _enemies = new List<Enemy>();

    private void Start()
    { 
        _enemies = FindObjectsOfType<Enemy>().ToList();
    }

    private void OnEnable()
    {
        _player.EnemyDestroyed += OnEnemyDestroyed;
    }

    private void OnDisable()
    {
        _player.EnemyDestroyed -= OnEnemyDestroyed;
    }

    private void OnEnemyDestroyed(Enemy enemy)
    {
        _enemies.Remove(enemy);

        CheckEndGame();
    }

    private void CheckEndGame()
    {
        if (_enemies.Count == 0)
        {
            GameOver?.Invoke();
        }
    }
}
