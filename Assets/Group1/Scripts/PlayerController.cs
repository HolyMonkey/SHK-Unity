using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;

    [SerializeField] private float _speed = 50f;

    private float _baseSpeed;
    private float _speedUpDuration = 5f;
    private int _speedUpMultiplier = 1;

    public event Action<Enemy> EnemyDied;

    private void Start()
    {
        _baseSpeed = _speed;
    }

    private void Update()
    {
        _rigidbody.velocity = GetMoveSpeed();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        SpeedAccselerator accselerator = collision.GetComponent<SpeedAccselerator>();

        if (enemy)
        {
            Destroy(enemy.gameObject);
            EnemyDied?.Invoke(enemy);
        }
        else if (accselerator)
        {
            AccselerateSpeed();
            Destroy(collision.gameObject);
        }
    }

    private Vector2 GetMoveSpeed()
    {
        float _horizontalSpeed = Input.GetAxisRaw("Horizontal");
        float _verticalSpeed = Input.GetAxisRaw("Vertical");

        return new Vector2(_horizontalSpeed, _verticalSpeed) * _speed * Time.deltaTime;
    }

    private IEnumerator AccselerationTimer()
    {
        yield return new WaitForSeconds(_speedUpDuration);

        _speed = _baseSpeed * --_speedUpMultiplier;
    }

    private void AccselerateSpeed()
    {
        _speed = _baseSpeed * ++_speedUpMultiplier;

        ReduceSpeed();
    }

    private void ReduceSpeed()
    {
        StartCoroutine(AccselerationTimer());
    }
}
