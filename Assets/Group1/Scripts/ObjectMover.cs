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
        SetRandomPosition();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        if (transform.position == _target)
            SetRandomPosition();
    }

    private void SetRandomPosition()
    {
        _target = Random.insideUnitCircle * _radius;
    }
}
