using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnvironmentTrigger : MonoBehaviour
{
    public event Action BonusCollecting;
    public event Action Attacking;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bonus>())
        {
            BonusCollecting.Invoke();
            Destroy(collision.gameObject);
        }
        else if (collision.GetComponent<Enemy>())
        {
            Attacking.Invoke();
            Destroy(collision.gameObject);
        }
    }
}
