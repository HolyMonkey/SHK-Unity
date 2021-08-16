using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _moveRadius;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = GetRandomTargetPosition();
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);

        if (transform.position == _targetPosition)
            _targetPosition = GetRandomTargetPosition();
    }

    private Vector3 GetRandomTargetPosition()
    {
        return Random.insideUnitCircle * _moveRadius;
    }
}
