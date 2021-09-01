using System;
using UnityEngine;

public class PlayerObjectInteraction : MonoBehaviour
{
    [SerializeField] private float _interactionDistance;

    public event Action<Enemy> EnemyCollided;
    public event Action<SpeedBooster> SpeedBoosterPicked;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Vector2.Distance(transform.position, collision.transform.position) < _interactionDistance)
        {
            InteractWithObject(collision.gameObject);
        }
    }

    private void InteractWithObject(GameObject collidedObject)
    {
        if (collidedObject.TryGetComponent(out Enemy enemy))
        {
            EnemyCollided?.Invoke(enemy);

            Destroy(enemy.gameObject);
        }

        if (collidedObject.TryGetComponent(out SpeedBooster booster))
        {
            SpeedBoosterPicked?.Invoke(booster);

            Destroy(booster.gameObject);
        }
    }
}
