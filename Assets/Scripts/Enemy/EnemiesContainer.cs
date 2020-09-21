using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemiesContainer : MonoBehaviour
{
    private Enemy[] _enemies;
    private PowerUp[] _powerUps;
    private int _liveEnemies;

    public event UnityAction PowerUpTimeStarted;
    public event UnityAction PowerUpTimeEnded;
    public event UnityAction AllDie;

    private void OnEnable()
    {
        _enemies = gameObject.GetComponentsInChildren<Enemy>();
        _liveEnemies = _enemies.Length;
        foreach (var enemy in _enemies)
        {
            enemy.CollisionWithPlayer += CountLiveEnemies;
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
            enemy.CollisionWithPlayer -= CountLiveEnemies;
        }
        foreach (var powerUp in _powerUps)
        {
            powerUp.ActivatePowerUp -= StartPowerUpTimer;
        }
    }

    private void CountLiveEnemies()
    {
        _liveEnemies--;
        if (_liveEnemies == 0)
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

    public void ResetLiveEnemiesCount()
    {
        _liveEnemies = _enemies.Length;
    }
}