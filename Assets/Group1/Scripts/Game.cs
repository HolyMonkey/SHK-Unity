using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject _endScreen;

    public void EndGame()
    {
        _endScreen.SetActive(true);
    }
}
