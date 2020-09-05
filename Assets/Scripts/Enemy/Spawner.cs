using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : ObjectPool
{
    [SerializeField] List<GameObject> _templates;
    [SerializeField] private Transform _parentForTemplates;
    

    private void Start()
    {
        foreach (var template in _templates)
        {
            Initialized(template);
            ResetEnemiesPosition();
        }
        
    }

    public void ResetEnemiesPosition()
    {
        if (TryGetObject(out GameObject[] enemies))
        {
            for (int i = 0; i < enemies.Length; i++)
            {
            Vector3 spawnPoint = new Vector3(Random.Range(1, 5), Random.Range(2, 4), 0);
            enemies[i].transform.position = spawnPoint;
            }
        }
    }
}
