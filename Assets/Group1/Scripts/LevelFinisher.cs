using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class LevelFinisher : MonoBehaviour
{
    [SerializeField] private GameObject _menu;

    private List<Enemy> _aliveEnemies;

    private void Start()
    {
        _aliveEnemies = GetComponentsInChildren<Enemy>().ToList<Enemy>();
    }

    private void OnEnable()
    {
        foreach (Enemy enemy in _aliveEnemies)
        {
            enemy.Died += AddKilledEnemy;
        }
    }
    
    private void OnDisable()
    {
        foreach (Enemy enemy in _aliveEnemies)
        {
            enemy.Died -= AddKilledEnemy;
        }
    }

    private void AddKilledEnemy(Enemy enemy)
    {
        _aliveEnemies.Remove(enemy);

        if (_aliveEnemies.Count > 0)
        {
            _menu.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}