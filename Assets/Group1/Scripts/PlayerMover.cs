using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeToDeceleration;

    private int _speedMultiplier;
    private int _overtime;
    private bool _isTimerActivated;

    private void Start()
    {
        _speedMultiplier = 2;
        _overtime = 3;
        _isTimerActivated = true;
    }

    private void Update()
    {
        Move();
        TryToDecreaseSpeed();
    }

    public void IncreaseSpeed()
    {
        _speed *= _speedMultiplier;
        _isTimerActivated = true;
        _timeToDeceleration = _overtime;
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector2.up * _speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector2.down * _speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector2.left * _speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    private void TryToDecreaseSpeed()
    {
        if (_isTimerActivated)
        {
            _timeToDeceleration -= Time.deltaTime;

            if (_timeToDeceleration < 0)
            {
                _isTimerActivated = false;
                _speed /= _speedMultiplier;
            }
        }
    }

}
