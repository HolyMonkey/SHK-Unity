using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpawner : MonoBehaviour
{
    [SerializeField] private SpeedBooster[] _boosters;
    [SerializeField] private float _spawnRadius;

    private void Start()
    {
        for (int i = 0; i < _boosters.Length; i++)
        {
            SpeedBooster booster = Instantiate(_boosters[i], Random.insideUnitCircle * _spawnRadius, Quaternion.identity);
        }
    }
}
