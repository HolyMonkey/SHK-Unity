using System.Collections;
using UnityEngine;

public class EnemyOwner : MonoBehaviour
{
    [SerializeField] private GameObject _menu;

    private int _killedEnemies = 0;
    private int _maxEnemiesNumber;

    private void Start()
    {
        _maxEnemiesNumber = GetComponentsInChildren<Enemy>().Length;
    }
 
    public void AddKilledEnemy()
    {
        _killedEnemies++;

        if (_killedEnemies >= _maxEnemiesNumber)
        {
            _menu.SetActive(true);
            enabled = false;
        }
    }
}