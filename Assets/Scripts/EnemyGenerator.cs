using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private float _generationRadius = 1;
    [SerializeField] private int _countEnemies = 4;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private EnemyCounter _enemyCounter;

    private void Start()
    {
        for (int i = 0; i < _countEnemies; i++)
        {
            Vector3 position = Random.insideUnitCircle.normalized * _generationRadius;
            Enemy newEnemy = Instantiate(_enemyPrefab, position, Quaternion.identity, transform).GetComponent<Enemy>();
            newEnemy.Init(_enemyCounter);
        }
    }
}
