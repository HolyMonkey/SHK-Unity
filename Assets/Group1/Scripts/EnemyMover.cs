using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _speed;

    private Vector2 _target;

    private void Start()
    {
        ChooseRandomDestinationPoint();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        if ((Vector2)transform.position == _target)
            ChooseRandomDestinationPoint();
    }

    private void ChooseRandomDestinationPoint()
    {
        _target = Random.insideUnitCircle * _radius;
    }
}
