using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Vector3 _target;
    private readonly float _radius = 4f;

    public Vector3 Target => _target;

    private void Start()
    {
        _target = Random.insideUnitCircle * _radius;
    }

    private void Update()
    {
        if (transform.position == _target)
            SetNextTarget();
    }

    private void SetNextTarget()
    {
        _target = Random.insideUnitCircle * _radius;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
