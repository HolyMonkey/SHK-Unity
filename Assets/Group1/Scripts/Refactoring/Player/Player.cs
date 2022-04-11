using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _startSpeed = 4;

    private bool _isBoosterActive;
    private float _currentSpeed;
    private float _speedMultiplier;
    private float _boosterDuration;

    public float CurrentSpeed => _currentSpeed;

    private void Start()
    {
        _currentSpeed = _startSpeed;
    }

    private void Update()
    {
        if (_isBoosterActive)
        {
            _boosterDuration -= Time.deltaTime;

            if (_boosterDuration < 0)
            {
                _isBoosterActive = false;
                _currentSpeed /= _speedMultiplier;
            }
        }
    }

    public void PickUpBooster(float speedMultiplier, float boosterDuration)
    {
        if (speedMultiplier <= 0)
            throw new ArgumentOutOfRangeException(nameof(speedMultiplier));   
        
        if (boosterDuration <= 0)
            throw new ArgumentOutOfRangeException(nameof(boosterDuration));

        _speedMultiplier = speedMultiplier;

        _isBoosterActive = true;

        _boosterDuration += boosterDuration;
        _currentSpeed *= _speedMultiplier;
    }
}
