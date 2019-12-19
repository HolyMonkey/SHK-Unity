using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckedEnemy : MonoBehaviour
{
    [SerializeField] private float _distance;

    [SerializeField] private GameObject _gameOver;
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject[] _enemies;

    public static CheckedEnemy Check { get; private set; }

    public static int CountEnemies { get; private set; }

    public void EndGame()
    {
        _gameOver.SetActive(true);
    }

    private void Start()
    {
        if (Check == null)
            Check = this;
        else
            Destroy(gameObject);

        CountEnemies = _enemies.Length;
        CountEnemies--;
    }

    private void Update()
    {
        ToCheckEnemies();
    }

    private void ToCheckEnemies()
    {
        foreach (var enemy in _enemies)
        {
            if (enemy != null)
            {
                if (Vector3.Distance(_player.position, enemy.transform.position) < _distance)
                {
                    _player.SendMessage("ToAttack", enemy);
                    CountEnemies--;
                }
            }
        }
    }
}
