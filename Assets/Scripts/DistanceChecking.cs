using System;
using System.Collections.Generic;
using UnityEngine;

public class DistanceChecking : MonoBehaviour
{
    [SerializeField] private float _minDistance = 0.2f;

    private Transform _player;
    private EnemiesSpawner _enemiesSpawner;
    private List<GameObject> _enemies;

    public void Init(PlayerSpawner playerSpawner, EnemiesSpawner enemiesSpawner)
    {
        _player = playerSpawner.Player.transform;
        _enemies = enemiesSpawner.Enemies;
    }

    private void Update()
    {
        for (int i = 0; i < _enemies.Count; i++)
        {
            var enemy = _enemies[i];
            if (Vector3.Distance(_player.position, enemy.transform.position) < _minDistance)
            {
                if (enemy.TryGetComponent(out EnemyHealth enemyHealth))
                    enemyHealth.Die();

                else
                    throw new ArgumentNullException("EnemyHealth");
            }
        }
    }
}