using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenu : Menu
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _exitButton;

    private void Start()
    {
        Time.timeScale = 0;
    }

    private void OnEnable()
    {
        _playButton.onClick.AddListener(StartGame);
        _exitButton.onClick.AddListener(ExitGame);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(StartGame);
        _exitButton.onClick.RemoveListener(ExitGame);
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        Close();
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        _playButton.interactable = false;
        _exitButton.interactable = false;
    }
}