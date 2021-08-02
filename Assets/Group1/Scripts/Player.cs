using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _isTimerRunning;
    [SerializeField] private float _timer;

    private PlayerMovement _playerMovement;
    private Game _game;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _game = FindObjectOfType<Game>();
    }

    private void Update()
    {
        if (_isTimerRunning)
        {
            _timer -= Time.deltaTime;

            if(_timer <= 0)
            {
                _isTimerRunning = false;
                _playerMovement.SetSpeed(_playerMovement.Speed / 2);
            }
        }

        EnemyMovement[] enemies = FindObjectsOfType<EnemyMovement>();

        if(enemies.Length == 0)
        {
            _game.EndGame();
            enabled = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<EnemyMovement>(out _))
        {
            Destroy(collision.gameObject);
        }
        
        if(collision.TryGetComponent<SpeedBooster>(out _))
        {
            _playerMovement.SetSpeed(_playerMovement.Speed * 2);
            _isTimerRunning = true;
            _timer = 2f;
        }
    }
}
