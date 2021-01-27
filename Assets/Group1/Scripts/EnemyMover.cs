using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _radius;

    private Vector3 _target;

    private void Start()
    {
        _target = Random.insideUnitCircle * _radius;
    }

    private void Update()
    {
        _rigidbody.velocity = (_target - transform.position).normalized * _speed * Time.deltaTime;

        if (transform.position == _target)
            _target = Random.insideUnitCircle * _radius;
    }
}
