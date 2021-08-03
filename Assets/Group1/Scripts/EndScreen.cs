using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private EnemiesList _enemiesList;
    [SerializeField] private GameObject _endScreen;

    private void OnEnable()
    {
        _enemiesList.EnemiesDied += OnEnemiesesDied;
    }

    private void OnDisable()
    {
        _enemiesList.EnemiesDied -= OnEnemiesesDied;
    }

    private void OnEnemiesesDied()
    {
        _endScreen.SetActive(true);
    }
}
