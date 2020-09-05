using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemiesContainer : MonoBehaviour
{
    public event UnityAction PowerUpTimeStarted;
    public event UnityAction PowerUpTimeEnded;

    public event UnityAction AllDie;
    private int _numberOfDeadEnemies;
   
    private Enemy[] _enemies;
    private PowerUp[] _powerUps;

    private void OnEnable()
    {
        _enemies = gameObject.GetComponentsInChildren<Enemy>();
        foreach (var enemy in _enemies)
        {
            enemy.CollisionWithPlayer += CountDeadEnemies;
        }
        _powerUps = gameObject.GetComponentsInChildren<PowerUp>();
        foreach (var powerUp in _powerUps)
        {
            powerUp.ActivatePowerUp += StartPowerUpTimer;
        }
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.CollisionWithPlayer -= CountDeadEnemies;
        }
        foreach (var powerUp in _powerUps)
        {
            powerUp.ActivatePowerUp -= StartPowerUpTimer;
        }
    }

    private void CountDeadEnemies()
    {
        _numberOfDeadEnemies++;
        if (_numberOfDeadEnemies == _enemies.Length)
        {
            AllDie?.Invoke();
        }
    }

    public void StartPowerUpTimer()
    {
        PowerUpTimeStarted?.Invoke();
        StartCoroutine(PowerUpTimeCountDown());
    }

    public IEnumerator PowerUpTimeCountDown()
    {
        yield return new WaitForSeconds(3);
        PowerUpTimeEnded?.Invoke();
    }
}
