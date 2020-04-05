using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if (transform.position == _targetPosition)
            _targetPosition = Random.insideUnitCircle * 4;
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, 2 * Time.deltaTime);
    }
}