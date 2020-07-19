using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 2;
    [SerializeField] private float _maxRadius = 4;
    private Vector3 _target;

    public event UnityAction<Enemy> Dead;

    private void Start()
    {
        SetRandomTarget();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        if (transform.position == _target)
            SetRandomTarget();
    }

    private void SetRandomTarget()
    {
        _target = Random.insideUnitCircle * _maxRadius;
    }

    public void Destroy()
    {
        Dead?.Invoke(this);
        Destroy(gameObject);
    }
}
