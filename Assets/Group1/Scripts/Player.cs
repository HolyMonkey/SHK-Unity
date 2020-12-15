using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction<Enemy> DestroiedEnemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Destroy(enemy.gameObject);

            DestroiedEnemy?.Invoke(enemy);
        }
    }
}
