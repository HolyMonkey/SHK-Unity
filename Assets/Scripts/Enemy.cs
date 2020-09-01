using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]private Vector3 _target;
    private int _radius = 4;
    private int _smooth = 2;

    private void Start()
    {
        ResetTarget();
    }
    
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _smooth * Time.deltaTime);

        if (transform.position == _target)
        {
            ResetTarget();
        }     
    }

    private void ResetTarget()
    {
        _target = Random.insideUnitCircle * _radius;
    }
}
