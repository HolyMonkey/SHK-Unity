using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _timeBoost = 2.0f;
    [SerializeField] private float _powerSpeedBoost = 2.0f;

    private float _maxSpeed;
    private float _minSpeed;
    private float _horizontalMove;
    private float _verticalMove;
    private float _temporaryEffect;

    public static UnityEvent EnemyDefeated = new UnityEvent();

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.Death();
            EnemyDefeated.Invoke();
        }

        if (collider.TryGetComponent<SpeedBoost>(out SpeedBoost speedBoost))
        {
            _temporaryEffect = _timeBoost;
            _speed = _maxSpeed;
        }
    }

    private void Start()
    {
        _maxSpeed = _speed * _powerSpeedBoost;
        _minSpeed = _speed;
    }

    private void Update()
    {
        _temporaryEffect -= Time.deltaTime;
        if (_temporaryEffect < 0)
            _speed = _minSpeed;

        _horizontalMove = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        _verticalMove = Input.GetAxis("Vertical") * _speed * Time.deltaTime;
        transform.Translate(_horizontalMove, _verticalMove, 0);
    }
}
