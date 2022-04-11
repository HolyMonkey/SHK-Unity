using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private SpeedBooster _speedBooster;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _enemyCount;
    [SerializeField] private int _boosterCount;
    [SerializeField] private float _spawnRadius;

    private int _countSpawnedEnemy;
    private int _countKilledEnemy;

    private void Start()
    {
        Spawn(_enemy.gameObject, _enemyCount);
        Spawn(_speedBooster.gameObject, _boosterCount);
    }

    private void Spawn(GameObject template, int count)
    {
        for (int i = 0; i < count; i++)
        {
            var spawned = Instantiate(template, Random.insideUnitCircle * _spawnRadius, Quaternion.identity);

            if (spawned.TryGetComponent(out Enemy enemy))
            {
                enemy.Died += OnEnemyDied;
                _countSpawnedEnemy++;
            }
        }
    }

    private void OnEnemyDied(Enemy enemy)
    {
        enemy.Died -= OnEnemyDied;
        _countKilledEnemy++;

        if (_countSpawnedEnemy == _countKilledEnemy)
        {
            _gameOverScreen.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
