using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(BoxCollider2D))]
public class Booster : MonoBehaviour
{
    [SerializeField] private float _time;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMove playerMove))
        {
            playerMove.Boost(_time);
            Destroy(gameObject);
        }
    }
}
