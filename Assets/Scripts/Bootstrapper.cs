using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private EnemiesSpawner _enemiesSpawner;
    [SerializeField] private PlayerSpawner _playerSpawner;
    [SerializeField] private DistanceChecking _distanceChecking;

    private void Start()
    {
        _playerSpawner.Init();
        _enemiesSpawner.Init();
        _distanceChecking.Init(_playerSpawner, _enemiesSpawner);
    }
}
