using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeactivatedEnemiesController : MonoBehaviour
{
    public event UnityAction NoEnemeisOnLevelReached;
    private int _numberOfDeactivatingEnemies;
   
    private Enemy[] _enemies;

    private void OnEnable()
    {
        _enemies = gameObject.GetComponentsInChildren<Enemy>();
        foreach (var enemy in _enemies)
        {
            enemy.GetComponent<EnemyCollisionHandler>().CollisionWithPlayerReached += CheckForActiveEnemy;
        }
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.GetComponent<EnemyCollisionHandler>().CollisionWithPlayerReached -= CheckForActiveEnemy;
        }
    }

    private void CheckForActiveEnemy()
    {
        _numberOfDeactivatingEnemies++;
        Debug.Log(_numberOfDeactivatingEnemies);
        if (_numberOfDeactivatingEnemies == _enemies.Length)
        {
            Debug.Log("Событие свершилось");
            NoEnemeisOnLevelReached?.Invoke();
            _numberOfDeactivatingEnemies = 0;
        }
    }
}
