using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMovement : MonoBehaviour
{
    private Vector3 _direction;
    private float _speed;
    private float _range;

    private void Start()
    {
        _direction = Random.insideUnitCircle * _range;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _direction, _speed * Time.deltaTime);
        if (transform.position == _direction)
            _direction = Random.insideUnitCircle * _range;
    }
}
