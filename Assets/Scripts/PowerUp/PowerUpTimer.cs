using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerUpTimer : MonoBehaviour
{
    private PowerUp[] _enemyWithPowerUp;

    public event UnityAction TimeStarted;
    public event UnityAction TimeEnded;

    private void Start()
    {
        _enemyWithPowerUp = FindObjectsOfType<PowerUp>(); 
        foreach (var enemy in _enemyWithPowerUp)
        {
            enemy.ActivatePowerUp += StartPowerUpTimer;
        }
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemyWithPowerUp)
        {
            enemy.ActivatePowerUp -= StartPowerUpTimer;
        }
    }

    public void StartPowerUpTimer()
    {
        TimeStarted?.Invoke();
        StartCoroutine(PowerUpTimeCountDown());
    }

    public IEnumerator PowerUpTimeCountDown()
    {
        yield return new WaitForSeconds(3);
        TimeEnded?.Invoke();
    }
}