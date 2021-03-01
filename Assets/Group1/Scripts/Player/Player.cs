using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _startSpeed;

    private float _currentSpeed;
    private bool _isBoosterActive;
    private float _boosterTimeLeft;
    private float _speedMultiplier;

    public float CurrentSpeed => _currentSpeed;

    private void Start()
    {
        _currentSpeed = _startSpeed;
    }

    private void Update()
    {
        if (_isBoosterActive == true)
        {
            _boosterTimeLeft -= Time.deltaTime;
            if (_boosterTimeLeft <= 0)
            {
                _isBoosterActive = false;
                _currentSpeed /= _speedMultiplier;
            }
        }
    }

    public void PickUpSpeedBooster(float speedMultiplier, float boosterDuration)
    {
        _speedMultiplier = speedMultiplier;

        _isBoosterActive = true;

        if (_isBoosterActive == true)
        {
            _boosterTimeLeft += boosterDuration;
        }
        else
        {
            _currentSpeed *= _speedMultiplier;
            _boosterTimeLeft = boosterDuration;
        }
    }
}
