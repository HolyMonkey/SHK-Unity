using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EndGameCounter : MonoBehaviour
{
    [SerializeField] private GameObject _endGameSprite;
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private List<EnemyMovement> _enemies;
    private float _minDistance;

    public void End()
    {
        _player.gameObject.SetActive(false);
        _endGameSprite.SetActive(true);
    }

    private void Update()
    {
        foreach (var square in _enemies)
        {
            if (square == null)
                continue;

            if (Vector3.Distance(_player.transform.position, square.transform.position) < _minDistance)
            {
                DestroyEnemy(square);
                if (CheckEnemyCount())
                {
                    End();
                }
            }
        }
    }

    private void DestroyEnemy(EnemyMovement enemy)
    {
        Destroy(enemy.gameObject);
    }

    private bool CheckEnemyCount()
    {
        _enemies = _enemies.Where(square =>square != null).ToList();
        if (_enemies.Count == 0)
        {
            return true;
        }

        return false;
    }
}
