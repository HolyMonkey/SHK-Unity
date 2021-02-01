using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public event UnityAction<Enemy> EnemyDying;

    public void Dying()
    {
        EnemyDying?.Invoke(this);
    }
}
