using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;

    [SerializeField] private float _speed = 50f;

    private float _baseSpeed;

    private float _speedUpDuration = 5f;

    public event Func<int> SpeedAccselerating;
    public event Func<int> SpeedAccselerationTimerPassed;

    public event Action EnemyDied;

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
            EnemyDied?.Invoke();
        }
        else if (accselerator)
        {
            _speed = _baseSpeed * (float)SpeedAccselerating?.Invoke();
            StartCoroutine(AccselerationTimer());
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
        while (_speed != _baseSpeed)
        {
            yield return new WaitForSeconds(_speedUpDuration);

            _speed = _baseSpeed * (float)SpeedAccselerationTimerPassed?.Invoke();
        }
    }
}
