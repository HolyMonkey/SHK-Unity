using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public event Action<EnemyHealth> OnDied;
    
    public void Die()
    {
        OnDied?.Invoke(this);
        Destroy(gameObject);
    }
}
