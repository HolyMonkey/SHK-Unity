using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyContainer : MonoBehaviour
{
    private List<Enemy> _enemies;

    public event UnityAction AllEnemiesDied;

    private void Start()
    {
        _enemies = new List<Enemy>(GetComponentsInChildren<Enemy>());
    }

    public void RemoveEnemy(Enemy enemy)
    {
        _enemies.Remove(enemy);

        if (_enemies.Count == 0)
        {
            AllEnemiesDied?.Invoke();
        }
    }

    public List<Enemy> GetEnemies()
    {
        return _enemies;
    }
}
