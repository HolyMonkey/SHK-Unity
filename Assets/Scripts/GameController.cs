using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private float _collisionDistance;
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _enemyContainer;

    private float _distance;
    private List<Enemy> _enemies;

    private void OnEnable()
    {
        _player.EnemyKilled += OnEnemyDead;
    }

    private void Start()
    {
        _enemies = new List<Enemy>(_enemyContainer.GetComponentsInChildren<Enemy>());
    }

    private void Update()
    {
        for (int i = _enemies.Count - 1; i >= 0; i--)
        {
            _distance = Vector3.Distance(_player.GetComponent<Transform>().position, _enemies[i].transform.position);
            if (_distance < _collisionDistance)
            {
                _player.OnCollision(_enemies[i]);
            }
        }
    }

    private void OnEnemyDead(Enemy enemy)
    {
        _enemies.Remove(enemy);

        if (_enemies.Count == 0)
        {
            GameEnd();
        }
    }

    private void GameEnd()
    {
        _endScreen.SetActive(true);
    }

    private void OnDisable()
    {
        _player.EnemyKilled -= OnEnemyDead;
    }
}
