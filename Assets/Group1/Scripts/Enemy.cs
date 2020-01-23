using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;

    private int _movementRadius = 4;
    private float _speed = 1;

    private Vector2 _target;

    private void Start()
    {
        _target = GetMovementDirection();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _rigidbody.position = Vector2.MoveTowards(_rigidbody.position, _target, _speed * Time.deltaTime);

        if (_rigidbody.position == _target)
        {
            _target = GetMovementDirection();
        }
    }

    private Vector2 GetMovementDirection()
    {
        return Random.insideUnitCircle * _movementRadius;
    }
}
