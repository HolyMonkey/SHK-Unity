using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _timer = 2f;
    private PlayerMovement _playerMovement;
    private Game _game;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _game = FindObjectOfType<Game>();
    }

    private void Update()
    {
        EnemyMovement[] enemies = FindObjectsOfType<EnemyMovement>();

        if(enemies.Length == 0)
        {
            _game.EndGame();
            enabled = false;
        }
    }

    private IEnumerator SpeedBoost()
    {
        _playerMovement.SetSpeed(_playerMovement.Speed * 2);
        yield return new WaitForSeconds(_timer);
        _playerMovement.SetSpeed(_playerMovement.Speed / 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<EnemyMovement>(out _))
        {
            Destroy(collision.gameObject);
        }
        
        if(collision.TryGetComponent<SpeedBooster>(out _))
        {
            StartCoroutine(SpeedBoost());
        }
    }
}
