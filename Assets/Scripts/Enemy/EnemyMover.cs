using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _radius;

    private Vector3 _target;

    private void Start()
    {
        NextTarget();
    }

    private void Update()
    {
        if (transform.position == _target)
        {
            NextTarget();
        }

        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
    }

    private void NextTarget()
    {
        _target = Random.insideUnitCircle * _radius;
    }
}
