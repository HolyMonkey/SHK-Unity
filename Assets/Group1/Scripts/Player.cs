using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    private List<EnemyMovement> _enemies;
    private float _timer = 2f;
    private PlayerMovement _playerMovement;
    private Game _game;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _game = FindObjectOfType<Game>();

        _enemies = FindObjectsOfType<EnemyMovement>().ToList();
    }

    private IEnumerator SpeedBoost()
    {
        _playerMovement.SetSpeed(_playerMovement.Speed * 2);
        yield return new WaitForSeconds(_timer);
        _playerMovement.SetSpeed(_playerMovement.Speed / 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out EnemyMovement enemyMovement))
        {
            _enemies.Remove(enemyMovement);

            if (_enemies.Count == 0)
            {
                _game.EndGame();
                enabled = false;
            }

            Destroy(collision.gameObject);
        }
        
        if(collision.TryGetComponent<SpeedBooster>(out _))
        {
            StartCoroutine(SpeedBoost());
        }
    }
}
