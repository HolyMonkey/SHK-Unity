using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyCount : MonoBehaviour
{
    [SerializeField] private GameObject _endGameSprite;
    [SerializeField] private PlayerMovement _greenCircle;
    [SerializeField] private List<EnemyMovement> _enemies;
    private float _minDistance;

    public void End()
    {
        _endGameSprite.SetActive(true);
    }

    private void Update()
    {
        foreach (var square in _enemies)
        {
            if (square == null)
                continue;

            if (Vector3.Distance(_greenCircle.transform.position, square.transform.position) < _minDistance)
            {
                DestroyEnemy(square);
                CheckEnemyCount();
            }
        }
    }

    private void DestroyEnemy(EnemyMovement square)
    {
        Destroy(square);
    }

    private void CheckEnemyCount()
    {
        _enemies = _enemies.Where(square =>square !=null).ToList();
        if (_enemies.Count == 0)
        {
            _greenCircle.enabled = false;
        }
    }
}
