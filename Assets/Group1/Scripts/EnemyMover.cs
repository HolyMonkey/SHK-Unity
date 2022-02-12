using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private Vector3 _targetPoint;
    private int _radius;
    private float _speed;

    private void Start()
    {
        _radius = 4;
        _targetPoint = Random.insideUnitCircle * _radius;
        _speed = 2f;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPoint, _speed * Time.deltaTime);

        if (transform.position == _targetPoint)
            _targetPoint = Random.insideUnitCircle * _radius;
    }
}
