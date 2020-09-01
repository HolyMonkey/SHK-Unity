using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameResults : MonoBehaviour
{
    [SerializeField] private GameObject _endPanel;
    [SerializeField] private Enemy[] _enemies;

    private void Start()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }

    public void CheckEnemys()
    {
        _enemies = _enemies.Where(x => x != null).ToArray();

        if (_enemies.Length == 1)
        {
            _endPanel.SetActive(true);
        }
    }
}
