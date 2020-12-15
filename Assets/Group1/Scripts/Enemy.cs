﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _radius = 4;
    [SerializeField] private float _speedBoost;

    public float SpeedBoost => _speedBoost;

    private Vector3 _target;

    private void Start()
    {
        GetNewPosition();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, Time.deltaTime);

        if (transform.position == _target)
        {
            GetNewPosition();
        }
    }

    private Vector3 GetNewPosition()
    {
        return _target = Random.insideUnitCircle * _radius;
    }
}
