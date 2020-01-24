using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;

    [SerializeField] private float _speed;

    private float _baseSpeed;
    private float _speedUpDuration = 2f;

    public event Func<float, float> SpeedAccselerating;

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
            _speed = (float)SpeedAccselerating?.Invoke(_speed);
            StartCoroutine(SpeedupTimer(_speedUpDuration));
        }
    }

    private Vector2 GetMoveSpeed()
    {
        float _horizontalSpeed = Input.GetAxisRaw("Horizontal");
        float _verticalSpeed = Input.GetAxisRaw("Vertical");

        return new Vector2(_horizontalSpeed, _verticalSpeed) * _speed * Time.deltaTime;
    }

    private IEnumerator SpeedupTimer(float duration)
    {
        yield return new WaitForSeconds(duration);

        _speed = _baseSpeed;
    }
}
