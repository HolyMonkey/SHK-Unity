using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemiesCounter : MonoBehaviour
{
    [SerializeField] private EnvironmentTrigger _environmentTrigger;
    private int _enemiesCount;

    public event Action EnemiesExpired;

    private void OnEnable()
    {
        _environmentTrigger.Attacking += OnAttacking;
    }

    private void OnDisable()
    {
        _environmentTrigger.Attacking += OnAttacking;
    }

    private void Start()
    {
        _enemiesCount = FindObjectsOfType<Enemy>().Length;
    }

    private void OnAttacking()
    {
        _enemiesCount--;
        if (_enemiesCount == 0)
        {
            EnemiesExpired.Invoke();
        }
    }
}