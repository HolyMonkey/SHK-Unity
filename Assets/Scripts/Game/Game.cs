using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameOverMenu _gameOverMenu;
    [SerializeField] private EndGameTrigger _endGameTrigger;
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _endGameTrigger.GameEnded += Reset;
    }

    private void OnDisable()
    {
        _endGameTrigger.GameEnded -= Reset;
    }

    private void Reset()
    {
        _spawner.Reset();
        _player.Reset();
        _gameOverMenu.Open();
    }
}
