using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private GameOverDisplay _gameOverDisplay;

    private Enemy[] _targets;
    private readonly float _minDistanceToTarget = .2f;

    private void Start()
    {
        _targets = FindObjectsOfType<Enemy>();
    }

    private void Update()
    {
        foreach (var target in _targets)
        {
            if (target != null)
            {
                if (Vector3.Distance(transform.position, target.transform.position) < _minDistanceToTarget)
                {
                    if (target.TryGetComponent<Enemy>(out Enemy enemy))
                    {
                        enemy.Die();
                        CheckNumberOfEnemies();
                    }
                }
            }
        }
    }

    private void CheckNumberOfEnemies()
    {
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();

        if (enemies.Length - 1 == 0)
        {
            _gameOverDisplay.gameObject.SetActive(true);
        }
    }
}