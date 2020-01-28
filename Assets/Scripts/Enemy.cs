using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _targetRadius;
    [SerializeField] private float _speed;

    private Vector3 _target;

    private void Start()
    {
        _target = GetNextTarget();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        if (transform.position == _target)
        {
            _target = GetNextTarget();
        }
    }

    private Vector3 GetNextTarget()
    {
        return Random.insideUnitCircle * _targetRadius;
    }
}
