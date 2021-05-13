using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 _target;
    private float _timeToSwitchDirection = 2f;
    private int _unitMultiplier = 4;

    private void Start()
    {
        _target = Random.insideUnitCircle * _unitMultiplier;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _timeToSwitchDirection * Time.deltaTime);

        if (transform.position == _target)
        {
            _target = Random.insideUnitCircle * _unitMultiplier;
        }
    }
}
