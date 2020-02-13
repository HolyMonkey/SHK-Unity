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
        _rigidbody.velocity = GetMovementDirection();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        SpeedAccelerator accelerator = collision.GetComponent<SpeedAccelerator>();

        if (enemy)
        {
            Destroy(enemy.gameObject);
            EnemyDied?.Invoke(enemy);
        }
        else if (accelerator)
        {
            AccelerateSpeed();
            Destroy(collision.gameObject);
        }
    }

    private Vector2 GetMovementDirection()
    {
        float _horizontalSpeed = Input.GetAxisRaw("Horizontal");
        float _verticalSpeed = Input.GetAxisRaw("Vertical");

        return new Vector2(_horizontalSpeed, _verticalSpeed) * _speed * Time.deltaTime;
    }

    private IEnumerator CheckAccelerationTimer()
    {
        yield return new WaitForSeconds(_speedUpDuration);

        _speed = _baseSpeed * --_speedUpMultiplier;
    }

    private void AccelerateSpeed()
    {
        _speed = _baseSpeed * ++_speedUpMultiplier;

        ReduceSpeed();
    }

    private void ReduceSpeed()
    {
        StartCoroutine(CheckAccelerationTimer());
    }
}
