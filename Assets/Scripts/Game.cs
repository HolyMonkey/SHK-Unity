using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Spawner _enemyGenerator;
    [SerializeField] private EnemiesContainer _deactivatedEnemiesController;
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private GameOverMenu _gameOverMenu;

    private void Start()
    {
        Time.timeScale = 0;
        _mainMenu.gameObject.SetActive(true);
        _gameOverMenu.gameObject.SetActive(false);
        _enemyGenerator.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        _mainMenu.PlayButtonClickReached += OnPlayButtonClick;
        _mainMenu.ExitButtonClickReached += OnExitButtonClick;
        _gameOverMenu.RestartButtonClickReached += OnRestartButtonClick;
        _gameOverMenu.ExitButtonClickReached += OnExitButtonClick;
        _deactivatedEnemiesController.GetComponent<EnemiesContainer>().AllDie += OnGameOver;
    }

    private void OnDisable()
    {
        _mainMenu.PlayButtonClickReached -= OnPlayButtonClick;
        _mainMenu.ExitButtonClickReached -= OnExitButtonClick;
        _gameOverMenu.RestartButtonClickReached -= OnRestartButtonClick;
        _gameOverMenu.ExitButtonClickReached -= OnExitButtonClick;
        _deactivatedEnemiesController.GetComponent<EnemiesContainer>().AllDie -= OnGameOver;
    }

    private void OnPlayButtonClick()
    {
        _mainMenu.gameObject.SetActive(false);
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _deactivatedEnemiesController.gameObject.SetActive(true);
        _gameOverMenu.gameObject.SetActive(false);
        StartGame();
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _deactivatedEnemiesController.gameObject.SetActive(true);
        _enemyGenerator.ResetPool();
        _enemyGenerator.ResetEnemiesPosition();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _player.gameObject.transform.position = new Vector3(0,0,0);
        _gameOverMenu.gameObject.SetActive(true); 
    }
}
