using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Vector3 _target;
    private float _radius = 4;
    private float _acceleration = 2;


    void Start()
    {
       CreateTargetToMove();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _acceleration * Time.deltaTime);
        if (transform.position == _target)
            CreateTargetToMove();
    }

    private void CreateTargetToMove()
    {
        _target = Random.insideUnitCircle * _radius;
    }
}
