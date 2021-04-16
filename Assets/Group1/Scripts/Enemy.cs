using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class Enemy : MonoBehaviour
{
    public UnityAction<Enemy> DeadEnemy;
    [SerializeField] private int _radiusNewPosition;
    [SerializeField] private float _speed;
    private Vector2 _targetPosition;

    private void Start()
    {
        SetNewTransformPosition();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
        if (new Vector2(transform.position.x, transform.position.y) == _targetPosition)
        {
            SetNewTransformPosition();
        }
    }

    private void SetNewTransformPosition()
    {
        _targetPosition = Random.insideUnitCircle * _radiusNewPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            DeadEnemy?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
