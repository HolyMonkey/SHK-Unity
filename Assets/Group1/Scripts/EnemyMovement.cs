using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private int _radiusModifier;
    [SerializeField] private int _speed;
    private Vector3 _target;

    private void Start()
    {
        ChangeTargetPosition();
    }
    
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        if (transform.position == _target) 
            ChangeTargetPosition();
    }

    private void ChangeTargetPosition()
    {
        _target = Random.insideUnitCircle * _radiusModifier;
    }
}
