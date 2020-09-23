using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Vector3 _target;
    private float _radius = 4;
    private float _speed = 2;

    private void Start()
    {
       CreateTarget();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        if (transform.position == _target)
        {
            CreateTarget();
        }
    }

    private void CreateTarget()
    {
        _target = Random.insideUnitCircle * _radius;
    }
}