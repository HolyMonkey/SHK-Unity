using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 _target;
    private float _speed = 2;
    private float _delay = 4;
    private Transform _transform;

    private void Start()
    {
        _target = Random.insideUnitCircle * _delay;
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        _transform.position = Vector3.MoveTowards(_transform.position, _target, _speed * Time.deltaTime);
        if (_transform.position == _target)
            _target = Random.insideUnitCircle * _delay;
    }

    public void GetDamage()
    {
        gameObject.SetActive(false);
    }
}
