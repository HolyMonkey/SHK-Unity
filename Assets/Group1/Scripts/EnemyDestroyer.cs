using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    [SerializeField]
    private float radiusOfDestroy;

    private void FixedUpdate()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, radiusOfDestroy);
        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out Enemy enemy))
                Destroy(enemy.gameObject);
        }
    }
}
