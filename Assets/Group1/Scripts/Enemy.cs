using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MoveIncideCircle
{
    public UnityAction<Enemy> Died;

    public void Die()
    {
        Died?.Invoke(this);
        Destroy(gameObject);
    }
}
