using System;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _playerTemplate;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private Transform _parent;
    [SerializeField] private EnemiesSpawner _enemiesSpawner;

    public event Action<Transform> OnPlayerSpawned;
    
    public  void Init()
    {
        GameObject player = Instantiate(_playerTemplate, _spawnPosition.transform.position, Quaternion.identity, _parent);
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        playerMovement.Init(_enemiesSpawner);
        OnPlayerSpawned?.Invoke(player.transform);
    }
}