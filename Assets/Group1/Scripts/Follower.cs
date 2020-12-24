using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public abstract class Follower : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _maxTargetDistance;

    private Vector3 _target;

    private void Start()
    {
        SetTargetPosition();
    }

    private void Update()
    {
        _rigidbody.velocity = (_target - transform.position).normalized * _moveSpeed;

        if (transform.position == _target)
            SetTargetPosition();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision) { }

    private void SetTargetPosition()
    {
        _target = Random.insideUnitCircle * _maxTargetDistance;
    }
}
