using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    [SerializeField] private bool _timePassed;
    [SerializeField] private float _elapsedTime;

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
            GameController.Constroller.End();
            enabled = false;
        }
    }

    public void SendMEssage(GameObject other)
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
