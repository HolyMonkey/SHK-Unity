using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Vector3 _target;
    private float _speed;
    private float _range;

    private void Start()
    {
        _target = NewTarget();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        if (transform.position == _target)
            _target = NewTarget();
    }

    private Vector3 NewTarget()
    {
        return Random.insideUnitCircle * _range;
    }
}
