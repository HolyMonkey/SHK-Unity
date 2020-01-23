using UnityEngine;

public class GameConditionController : MonoBehaviour
{
    enum GameState { Play,EndGame };

    [SerializeField] private GameObject _endGameInterface;
    [SerializeField] private PlayerController _player;

    [SerializeField] private Enemy[] _enemies;

    private int _allEnemiesDead = 0;

    private GameState _state = GameState.Play;
    private void OnEnable()
    {
        _player.EnemyDied += CountAliveEnemyInGame;
    }

    private void Start()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }

    private void Update()
    {
        if (_allEnemiesDead == _enemies.Length)
        {
            SetGameState(_state);
        }
    }

    private void CountAliveEnemyInGame()
    {
        _allEnemiesDead++;
    }

    private void SetGameState(GameState state)
    {
        if (_state == GameState.Play)
        {
            SetEndGameState();
        }
    }

    private void SetEndGameState()
    {
        _player.enabled = false;
        _endGameInterface.SetActive(true);
    }
}
