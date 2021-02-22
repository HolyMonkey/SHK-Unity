using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class LevelFinisher : MonoBehaviour
{
    [SerializeField] private GameObject _menu;

    private int _maxEnemiesNumber;

    private List<Enemy> _deadEnemies;
    private List<Enemy> _aliveEnemies;

    private void Start()
    {
        _deadEnemies = new List<Enemy>();

        _aliveEnemies = GetComponentsInChildren<Enemy>().ToList<Enemy>();
        _maxEnemiesNumber = _aliveEnemies.Count;

        foreach(Enemy enemy in _aliveEnemies)
        {
            enemy.Init(this);
        }
    }


    public void AddKilledEnemy(Enemy enemy)
    {
        _deadEnemies.Add(enemy);

        if (_deadEnemies.Count >= _maxEnemiesNumber)
        {
            _menu.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}