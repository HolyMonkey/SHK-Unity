using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public event Action<EnemyHealth> Died;
    
    public void Die()
    {
        Died?.Invoke(this);
        Destroy(gameObject);
    }
}
