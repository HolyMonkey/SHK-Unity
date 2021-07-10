using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(Game))]
public class Player : MonoBehaviour
{
    [SerializeField] private bool _timePassed;
    [SerializeField] private float _elapsedTime;
    [SerializeField] private Game _game;

    private PlayerMover _playerMover;
    
    private const string Enemy = "Enemy";
    private const string Speed = "speed";

    void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        if (_timePassed)
        {
            _elapsedTime -= Time.deltaTime;
            if (_elapsedTime < 0)
            {
                _timePassed = false;
                _playerMover.Speed /= 2;
            }
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(Enemy);

        if (enemies.Length == 0)
        {
            _game.End();
            enabled = false;
        }
    }

    public void SendMessage(GameObject other)
    {
        if(other.name == Enemy)
        {
            Destroy(other);
        }

        if (other.name == Speed)
        {
            _playerMover.Speed *= 2;
            _timePassed = true;
            _elapsedTime = 2;
        }
    }
}
