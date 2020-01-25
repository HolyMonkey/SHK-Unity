using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;

    [SerializeField] private float _speed = 50f;

    private float _baseSpeed;

    private float _speedUpDuration;
    private float _speedUpBaseDuration = 5f;

    private bool IsAccselerated;

    public event Func<float, float> SpeedAccselerating;

    public event Action EnemyDied;

    private void Start()
    {
        _baseSpeed = _speed;
    }

    private void Update()
    {
        _rigidbody.velocity = GetMoveSpeed();

        if (IsAccselerated)
        {
            AccselerationTimer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        SpeedAccselerator accselerator = collision.GetComponent<SpeedAccselerator>();

        if (enemy)
        {
            Destroy(enemy.gameObject);
            EnemyDied?.Invoke();
        }
        else if (accselerator)
        {
            _speed = (float)SpeedAccselerating?.Invoke(_speed);
            IsAccselerated = true;
            _speedUpDuration = _baseDuration;
        }
    }

    private Vector2 GetMoveSpeed()
    {
        float _horizontalSpeed = Input.GetAxisRaw("Horizontal");
        float _verticalSpeed = Input.GetAxisRaw("Vertical");

        return new Vector2(_horizontalSpeed, _verticalSpeed) * _speed * Time.deltaTime;
    }

    private void AccselerationTimer()
    {
        _speedUpDuration -= Time.deltaTime;

        if (_speedUpDuration <= 0)
        {
            IsAccselerated = false;
            _speed = _baseSpeed;
            _speedUpDuration = _speedUpBaseDuration;
        }
    }
}
