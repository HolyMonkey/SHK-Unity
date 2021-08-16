using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] private Player _player;

    public event UnityAction GameOver;

    private List<EnemyMover> _enemies = new List<EnemyMover>();

    private void Start()
    {
        _enemies = FindObjectsOfType<EnemyMover>().ToList();
    }

    private void OnEnable()
    {
        _player.EnemyDestroyed += OnEnemyDestroyed;
    }

    private void OnDisable()
    {
        _player.EnemyDestroyed -= OnEnemyDestroyed;
    }

    private void OnEnemyDestroyed(EnemyMover enemy)
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
