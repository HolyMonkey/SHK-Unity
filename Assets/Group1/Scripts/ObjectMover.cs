using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] private float _radiusOfTargetPositions;
    [SerializeField] private float _moveSpeed;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = Random.insideUnitCircle * _radiusOfTargetPositions;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, 2 * Time.deltaTime);

        if (transform.position == _targetPosition)
            _targetPosition = Random.insideUnitCircle * _radiusOfTargetPositions;
    }
}
