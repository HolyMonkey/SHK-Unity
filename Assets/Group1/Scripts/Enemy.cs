using UnityEngine;
using UnityEngine.Events;

public class Enemy : CollectedObjects
{
    public event UnityAction Died;

    public void Die()
    {
        Died?.Invoke();

        Destroy(gameObject);
    }
}
