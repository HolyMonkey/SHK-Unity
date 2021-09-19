using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeadScreen : MonoBehaviour
{
    [SerializeField] private Image _deadScreenLable;

    public void OnVictory()
    {
        _deadScreenLable.gameObject.SetActive(true);
    }

    public void OnPlayAgainButtonDown()
    {
        SceneManager.LoadScene(0);
    }

    public void OnExitButtonDown()
    {
        Application.Quit();
    }
}