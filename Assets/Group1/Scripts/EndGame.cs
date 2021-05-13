using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private GameObject[] _enemies;

    private int _countEnemy;

    private void Start()
    {
        _countEnemy = _enemies.Length;
    }

    private void Update()
    {
        if (_countEnemy == 0)
        {
            End();
        }
    }

    private void End()
    {
        _endScreen.SetActive(true);
    }

    public void DestroyEnemy(GameObject enemy)
    {
        _countEnemy--;
        Destroy(enemy);
    }
}
