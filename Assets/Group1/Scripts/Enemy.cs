﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public UnityEvent Died;

    public void Die()
    {
        Died.Invoke();
        Destroy(gameObject);
    }
}
