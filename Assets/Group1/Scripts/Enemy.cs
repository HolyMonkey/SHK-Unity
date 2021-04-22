using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _speed;
    private Vector2 _target;
    public UnityAction<Enemy> Dead;

    private void Start()
    {
        ChangeTarget();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        if ((Vector2)transform.position == _target)
        {
            ChangeTarget();
        }
    }

    private void ChangeTarget()
    {
        _target = Random.insideUnitCircle * _radius;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            Dead?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
