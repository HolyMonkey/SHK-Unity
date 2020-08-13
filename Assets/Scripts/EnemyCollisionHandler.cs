using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyCollisionHandler : MonoBehaviour
{
    public event UnityAction CollisionWithPlayerReached;
    
    public bool IsCollisionWithPlayerReached { get; private set; }

    private void OnEnable()
    {
        ResetCollisionWithPlayer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.gameObject.TryGetComponent(out Player player))
            {
                IsCollisionWithPlayerReached = true;
                CollisionWithPlayerReached?.Invoke();
                gameObject.SetActive(false);
            }
    }

    public void ResetCollisionWithPlayer()
    {
        IsCollisionWithPlayerReached = false;
    }
}

