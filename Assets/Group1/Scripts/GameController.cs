using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _endGameScreen;
    [SerializeField] private Player _player;
    [SerializeField] private Enemy[] _enemies;

    public static GameController Controller;

    private float _destroyDistance;

    private void Start()
    {
        Controller = this;
        _destroyDistance = 0.5f;
    }

    private void Update()
    {
        foreach (var enemy in _enemies)
        {
            if (enemy == null)
                continue;

            if (Vector3.Distance(_player.transform.position, 
                enemy.transform.position) < _destroyDistance)
            {
                _player.KillEnemy(enemy);
            }
        }
    }

    public void FinishGame()
    {
        _endGameScreen.SetActive(true);
    }
}
