using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction<Enemy> EnemyDestroyed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Destroy(enemy.gameObject);

            EnemyDestroyed?.Invoke(enemy);
        }
    }
}
