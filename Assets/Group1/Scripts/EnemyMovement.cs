using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private int _radiusModifier;
    [SerializeField] private int _speed;
    private Vector3 _targetPosition;

    private void Start()
    {
        SetTargetPosition();
    }
    
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
        if (transform.position == _targetPosition) 
            SetTargetPosition();
    }

    private void SetTargetPosition()
    {
        _targetPosition = Random.insideUnitCircle * _radiusModifier;
    }
}
