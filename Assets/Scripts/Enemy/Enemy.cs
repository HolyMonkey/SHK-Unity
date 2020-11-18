using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public event UnityAction CollisionWithPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMovement player))
        {
            gameObject.SetActive(false);
            CollisionWithPlayer?.Invoke();
        }
    }
}