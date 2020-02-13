using UnityEngine;

public class GameEnder : MonoBehaviour
{
    [SerializeField] private GameObject _endGameInterface;

    [SerializeField] private EndGameChecker _endGameChecker;

    private void OnEnable()
    {
        _endGameChecker.AllEnemiesDied += OnAllEnemiesDied;
    }

    private void OnDisable()
    {
        _endGameChecker.AllEnemiesDied -= OnAllEnemiesDied;
    }

    private void OnAllEnemiesDied()
    {
        _endGameInterface.SetActive(true);
    }
}
