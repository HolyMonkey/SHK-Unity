using System;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _playerTemplate;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private Transform _parent;
    [SerializeField] private EnemiesSpawner _enemiesSpawner;

    public GameObject Player { get; private set; }
    
    public event Action<Transform> Spawned;
    
    public  void Init()
    {
        Player = Instantiate(_playerTemplate, _spawnPosition.transform.position, Quaternion.identity, _parent);
        PlayerMovement playerMovement = Player.GetComponent<PlayerMovement>();
        playerMovement.Init(_enemiesSpawner);
        Spawned?.Invoke(Player.transform);
    }
}