using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _templates;
    [SerializeField] private ObjectPool _objectPool;


    private void Awake()
    {
        foreach (var template in _templates)
        {
            _objectPool.Initialized(template);
            ResetEnemiesPosition();
        }
    }

    private void ResetEnemiesPosition()
    {
        if (_objectPool.TryGetObject(out GameObject[] enemies))
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                Vector3 spawnPoint = new Vector3(Random.Range(1, 5), Random.Range(2, 4), 0);
                enemies[i].transform.position = spawnPoint;
            }
        }
    }

    public void Reset()
    {
        _objectPool.Reset();
        ResetEnemiesPosition();
    }
}
