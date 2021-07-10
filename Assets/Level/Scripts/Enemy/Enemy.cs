using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _radius;
    private Vector3 _target;

    private void Start()
    {
        SetTarget();
    }

    private void SetTarget()
    {
        _target = Random.insideUnitCircle * _radius;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, 2 * Time.deltaTime);
        if (transform.position == _target)
            SetTarget();
    }
}
