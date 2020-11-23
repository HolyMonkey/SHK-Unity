using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController controller;

    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private Player _player;
    [SerializeField] private Enemy[] _enemies;

    private void Start()
    {
        controller = this;
    }

    private void Update(){
        foreach (var enemy in _enemies)
        {
            if (enemy == null)
                continue;

                if (Vector3.Distance(_player.transform.position, enemy.transform.position) < 0.2f)
                {
                    _player.SendMessage("SendMEssage", enemy);
                }

        }

        if (_enemies.Length == 0)
        {
            GameOver();
        }

    }

    public void GameOver()
    {
        _gameOverScreen.SetActive(true);
    }
}
