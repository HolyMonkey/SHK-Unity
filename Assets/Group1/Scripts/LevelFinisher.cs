using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelFinisher : MonoBehaviour
{
    [SerializeField] private GameObject _menu;

    private int _maxEnemiesNumber;
    private List<Enemy> _deadEnemies;

    private void Start()
    {
        _deadEnemies = new List<Enemy>();
        _maxEnemiesNumber = GetComponentsInChildren<Enemy>().Length;
    }

    private void OnEnable()
    {
        Enemy.Singleton.DeathEvent += AddKilledEnemy;
    }

    public void AddKilledEnemy(Enemy enemy)
    {
        if (_deadEnemies.Count >= _maxEnemiesNumber)
        {
            _menu.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}