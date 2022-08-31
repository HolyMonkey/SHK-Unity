using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _radius = 4.0f;
    [SerializeField] private float _speed = 2.0f;
    private Vector3 _target;

    public void Death()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        ChangeTarget();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        if (transform.position == _target)
            ChangeTarget();
    }

    private void ChangeTarget()
    {
        _target = Random.insideUnitCircle * _radius;
    }

}
