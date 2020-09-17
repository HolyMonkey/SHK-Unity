using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _radius;

    private Vector3 _target;

    private void Start()
    {
        CreateTargetPosition();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        if (transform.position == _target)
            CreateTargetPosition();
    }

    private void CreateTargetPosition()
    {
        _target = Random.insideUnitCircle * _radius;
    }
}
