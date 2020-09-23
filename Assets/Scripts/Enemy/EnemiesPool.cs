using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesPool : MonoBehaviour
{
    private Enemy[] _enemies;
    private PowerUp[] _powerUps;
    
    private void OnEnable()
    {
        _enemies = gameObject.GetComponentsInChildren<Enemy>();
        _powerUps = gameObject.GetComponentsInChildren<PowerUp>();
    }

    public PowerUp[] GetEnemiesWithPowerUp()
    {
        return _powerUps;
    }

    public Enemy[] GetEnemies()
    {
        return _enemies;
    }
}