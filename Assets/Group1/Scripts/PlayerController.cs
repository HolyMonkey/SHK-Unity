using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;

    [SerializeField] private float _speed;

    private float _baseSpeed;

    public delegate float SpeedUp(float speed);
    public event SpeedUp AccseleratingSpeed;

    public delegate void EnemyDiedNotification();
    public event EnemyDiedNotification EnemyDied;

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
            _baseSpeed = _speed;
            _speed = (float)AccseleratingSpeed?.Invoke(_speed);
            Destroy(accselerator.gameObject);
            ReturnToBaseSpeed();
        }
    }

    private Vector2 GetMoveSpeed()
    {
        float _horizontalSpeed = Input.GetAxisRaw("Horizontal") * _speed * Time.deltaTime;
        float _verticalSpeed = Input.GetAxisRaw("Vertical") * _speed * Time.deltaTime;

        return new Vector2(_horizontalSpeed, _verticalSpeed);
    }

    IEnumerator ReturnToBaseSpeed()
    {
        yield return new WaitForSeconds(2f);

        _speed = _baseSpeed;
    }
}
