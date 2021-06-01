using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]

public class Enemy : MonoBehaviour
{
    public event UnityAction<Enemy> Dying;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMover>())
        {
            Dying?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
