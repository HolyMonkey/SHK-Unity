using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _distance;

    private Vector3 _targetPosition;

    private void Start()
    {
        GetNewPosition();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, Time.deltaTime);

        if (transform.position == _targetPosition)
        {
            GetNewPosition();
        }
    }

    private Vector3 GetNewPosition()
    {
        return _targetPosition = Random.insideUnitCircle * _distance;
    }
}
