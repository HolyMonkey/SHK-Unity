using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private GameResults _gameResults;

    private float _minDistance = 0.2f;

    private void Start()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }

    private void Update()
    {
        foreach (var enemy in _enemies)
        {
            if (enemy == null)
                continue;

            if (Vector3.Distance(gameObject.transform.position, enemy.gameObject.transform.position) < _minDistance)
            {
                Destroy(enemy.gameObject);
                _gameResults.CheckEnemys();
            }
        }
    }
}
