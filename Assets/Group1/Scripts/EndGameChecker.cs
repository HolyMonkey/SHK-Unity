using UnityEngine;

public class EndGameChecker : MonoBehaviour
{
    [SerializeField] private GameObject _endGameInterface;
    [SerializeField] private PlayerController _player;

    [SerializeField] private Enemy[] _enemies;

    private int _allEnemiesDead = 0;

    private void OnEnable()
    {
        _player.EnemyDied += OnEnemyDied;
    }

    private void Start()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }

    private void OnDisable()
    {
        _player.EnemyDied -= OnEnemyDied;
    }

    private void OnEnemyDied()
    {
        _allEnemiesDead++;
        IsAllEnemiesDied();
    }

    private void SetEndGameState()
    {
        _player.enabled = false;
        _endGameInterface.SetActive(true);
    }

    private void IsAllEnemiesDied()
    {
        if (_allEnemiesDead == _enemies.Length)
        {
            SetEndGameState();
        }
    }
}
