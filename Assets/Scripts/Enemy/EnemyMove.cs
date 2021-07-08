using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMove : MonoBehaviour
{
    private readonly float _speed = 2f;
    private Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _enemy.Target, _speed * Time.deltaTime);
    }
}
