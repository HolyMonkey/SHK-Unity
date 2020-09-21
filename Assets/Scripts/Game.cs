using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameOverMenu _gameOverMenu;
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private EnemiesContainer _enemiesContainer;
    [SerializeField] private Player _player;
    [SerializeField] private Spawner _spawner;

    private void Start()
    {
        _enemiesContainer.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        _gameOverMenu.GameRestarted += Reset;
        _enemiesContainer.GetComponent<EnemiesContainer>().AllDie += _gameOverMenu.Open;
    }

    private void OnDisable()
    {
        _gameOverMenu.GameRestarted -= Reset;
        _enemiesContainer.GetComponent<EnemiesContainer>().AllDie -= _gameOverMenu.Open;
    }

    private void Reset()
    {
        _player.gameObject.transform.position = new Vector3(0, 0, 0);
        _enemiesContainer.ResetLiveEnemiesCount();
        _spawner.ResetPool();
        _spawner.ResetEnemiesPosition();
        _player.GetComponent<PlayerMovement>().ResetSpeed();
    }
}
