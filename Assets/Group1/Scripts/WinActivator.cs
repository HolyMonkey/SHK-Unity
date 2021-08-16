using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinActivator : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private GameObject _winScreen;

    public void DeleteEnemy()
    {
        _enemies.RemoveAt(0);

        if (_enemies.Count == 0)
            _winScreen.SetActive(true);
    }
}
