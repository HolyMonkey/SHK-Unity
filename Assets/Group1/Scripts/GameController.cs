using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController ControllerGame;

    [SerializeField] private GameObject _deathPanel;
    [SerializeField] private GameObject _playerObject;
    [SerializeField] private GameObject[] _enemyArray;

    void Start()
    {
        ControllerGame = this;
    }

    public void End()
    {
        _deathPanel.SetActive(true);
    }

    void Update(){
        bool endGame = true;
        foreach (var b in _enemyArray)
        {
            if (b == null)
                continue;
            endGame = false;
            if (Vector2.Distance(_playerObject.gameObject.gameObject.GetComponent<Transform>().position, b.gameObject.gameObject.transform.position) < 0.2f)
            {
                Destroy(b.gameObject);
            }
        }
        if (endGame)
        {
            _playerObject.GetComponent<PlayerMoving>().EndGame();
            End();
        }
    }
}
