using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInsideCircle : MonoBehaviour
{
    [SerializeField] private float _radius = 4;
    [SerializeField] private float _speed = 2;

    private Vector3 _target_target;

    private void Start()
    {
        SelectTarget();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target_target, _speed * Time.deltaTime);

        if (transform.position == _target_target)
            SelectTarget();
    }

    private void SelectTarget()
    {
        _target_target = Random.insideUnitCircle * _radius;
    }
}
