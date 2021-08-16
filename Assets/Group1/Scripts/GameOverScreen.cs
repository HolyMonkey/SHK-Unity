using UnityEngine;
using UnityEngine.UI;
using IJunior.TypedScenes;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private EnemyCounter _enemyCounter;
    [SerializeField] private GameObject _panel;

    private CanvasGroup _gameOverGroup;

    private void OnEnable()
    {
        _enemyCounter.GameOver += OnDied;
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnExit);
    }

    private void OnDisable()
    {
        _enemyCounter.GameOver -= OnDied;
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExit);
    }

    private void Start()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();
        _gameOverGroup.alpha = 0;
    }

    private void OnDied()
    {
        Time.timeScale = 0;
        _gameOverGroup.alpha = 1;
    }

    private void OnRestartButtonClick()
    {
        Time.timeScale = 1;
        KillAllEnemies.Load();
    }

    private void OnExit()
    {
        Application.Quit();
    }
}
