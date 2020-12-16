using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2;
    [SerializeField] private float moveRange = 4;

    private Vector3 target;

    public event Action<Enemy> Destroyed;

    private void Start()
    {
        PickNewTarget();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
        if (transform.position == target)
            PickNewTarget();
    }

    private void OnDestroy()
    {
        Destroyed?.Invoke(this);
    }

    private void PickNewTarget() 
    {
        target = Random.insideUnitCircle * moveRange;
    }
}
