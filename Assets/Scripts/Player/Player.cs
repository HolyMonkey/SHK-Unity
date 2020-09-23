using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PowerUpTimer _powerUpTimer;

    private float _speed = 5;
    private float _coefficientOfSpeedChange = 2;

    private void OnEnable()
    {
        _powerUpTimer.TimeStarted += IncreaseSpeed;
        _powerUpTimer.TimeEnded += ReduceSpeed;
    }

    private void OnDisable()
    {
        _powerUpTimer.TimeStarted -= IncreaseSpeed;
        _powerUpTimer.TimeEnded -= ReduceSpeed;
    }

    private void Update()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        transform.position += moveDirection.normalized * _speed * Time.deltaTime;
    }

    private float GetIncreaseSpeed()
    {
        return _speed *= _coefficientOfSpeedChange;
    }

    private float GetReduceSpeed()
    {
        if (_speed > 5)
        {
            _speed /= _coefficientOfSpeedChange;
        }
        return _speed;
    }

    private void IncreaseSpeed()
    {
        GetIncreaseSpeed();
    }
    private void ReduceSpeed()
    {
        GetReduceSpeed();
    }

    private void ResetSpeed()
    {
        _speed = 5;
    }

    private void ResetPosition()
    {
        gameObject.transform.position = new Vector3(0, 0, 0);
    }

    public void Reset()
    {
        ResetPosition();
        ResetSpeed();
    }
}