using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public UnityAction<Enemy> Died;

    public void Dying()
    {
        Died?.Invoke(this);
        Destroy(gameObject);
    }
}