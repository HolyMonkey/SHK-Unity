using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveIncideCircle : MonoBehaviour
{
    [SerializeField] private float _maxDistance = 4;
    [SerializeField] private float _speed = 2;

    private Vector3 _targetPosition;

    private void Start()
    {
        SelectTarget();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);

        if (transform.position == _targetPosition)
            SelectTarget();
    }

    private void SelectTarget()
    {
        _targetPosition = Random.insideUnitCircle * _maxDistance;
    }
}
