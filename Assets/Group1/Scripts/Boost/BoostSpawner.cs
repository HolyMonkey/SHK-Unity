using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpawner : MonoBehaviour
{
    [SerializeField] private SpeedBooster _boosterPrefab;
    [SerializeField] private int _boosterCount;
    [SerializeField] private float _spawnRadius;

    private void Start()
    {
        for (int i = 0; i < _boosterCount; i++)
        {
            SpeedBooster booster = Instantiate(_boosterPrefab, Random.insideUnitCircle * _spawnRadius, Quaternion.identity);
            booster.GetComponent<ObjectMover>().SetNewTargetPosition();
        }
    }
}
