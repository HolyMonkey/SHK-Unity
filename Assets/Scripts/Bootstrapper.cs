using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private EnemiesSpawner _enemiesSpawner;
    [SerializeField] private PlayerSpawner _playerSpawner;

    private void Start()
    {
        _enemiesSpawner.Init();
        _playerSpawner.Init();
    }
}
