using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _target;

    private void Start()
    {
        SetNextTarget();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        if (transform.position == _target)
            SetNextTarget();
    }

    private void SetNextTarget()
    {
        _target = Random.insideUnitCircle * 4;
    }
}
