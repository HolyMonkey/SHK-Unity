using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _timer;
    [SerializeField] private float _totalTime;

    private float _timeLeft;

    public float Speed => _speed;

    private void Update()
    {
        if (_timer)
        {
            _timeLeft -= Time.deltaTime;
            if (_timeLeft <= 0)
            {
                _timer = false;
                _speed /= 2;
            }
        }
    }

    public void PickUpSpeedBooster(float speedMultiplier)
    {
        _speed *= speedMultiplier;
        _timer = true;
        _timeLeft = _totalTime;
    }
}
