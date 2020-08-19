using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject _endGamePanel;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject[] _enemies;

    private void OnEnable()
    {
        _player.EnemyCatched += CatchEnemy;
    }

    private void OnDisable()
    {
        _player.EnemyCatched -= CatchEnemy;
    }

    private void CatchEnemy(GameObject enemy)
    {
        enemy.gameObject.SetActive(false);
        CheckEndGame();
    }

    private void CheckEndGame()
    {
        foreach(GameObject enemy in _enemies)
        {
            if (enemy.active == true)
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
