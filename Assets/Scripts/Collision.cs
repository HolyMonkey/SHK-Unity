using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] private EnemyContainer _enemyContainer;
    [SerializeField] private float _collisionDistance;
    [SerializeField] private Player _player;

    private List<Enemy> _enemies;
    private float _distance;

    private void Start()
    {
        _enemies = _enemyContainer.GetEnemies();
    }

    private void Update()
    {
        for (int i = _enemies.Count - 1; i >= 0; i--)
        {
            _distance = Vector3.Distance(_player.transform.position, _enemies[i].transform.position);
            if (_distance < _collisionDistance)
            {
                Enemy enemy = _enemies[i];
                _enemyContainer.RemoveEnemy(enemy);
                _player.OnCollision(enemy);
            }
        }
    }
}
