using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : MonoBehaviour
{
    [SerializeField] private int _multyplier;
    [SerializeField] private float _duration;

    public int Muliplier => _multyplier;
    public float Duration => _duration;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMover mover))
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
