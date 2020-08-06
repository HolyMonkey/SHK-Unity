using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject _endGamePanel;
    [SerializeField] private Player _player;
    [SerializeField] private Enemy[] _enemies;

    private bool _isGameOver = false;

    private void OnEnable()
    {
        _player.enemyCatched += CatchEnemy;
    }

    private void OnDisable()
    {
        _player.enemyCatched -= CatchEnemy;
    }

    private void CatchEnemy(Enemy enemy)
    {
        enemy.enabled = false;
        CheckEndGame();
    }

    private void CheckEndGame()
    {
        foreach(Enemy enemy in _enemies)
        {
            if (enemy.enabled == true)
                return;
        }

        EndGame();
    }

    public void EndGame()
    {
        _player.enabled = false;
        _endGamePanel.SetActive(true);
    }
}
