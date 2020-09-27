using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameOverMenu : Menu
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;

    private void Start()
    {
        CanvasGroup.blocksRaycasts = false;
    }

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(RestartGame);
        _exitButton.onClick.AddListener(ExitGame);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(RestartGame);
        _exitButton.onClick.RemoveListener(ExitGame);
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private void RestartGame()
    {
        Time.timeScale = 1;
        Close();
    }

    public void Open()
    {
        CanvasGroup.blocksRaycasts = true;
        CanvasGroup.alpha = 1;
        _restartButton.interactable = true;
        _exitButton.interactable = true;
        Time.timeScale = 0;
    }

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        _restartButton.interactable = false;;
        _exitButton.interactable = false;
    }
}