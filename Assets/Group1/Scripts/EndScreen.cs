using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private EnemyList _enemyList;
    [SerializeField] private GameObject _endScreen;

    private void OnEnable()
    {
        _enemyList.EnemiesDied += OnEnemiesDied;
    }

    private void OnDisable()
    {
        _enemyList.EnemiesDied -= OnEnemiesDied;
    }

    private void OnEnemiesDied()
    {
        _endScreen.SetActive(true);
    }
}
