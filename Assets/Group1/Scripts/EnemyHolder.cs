using System.Collections;
using UnityEngine;

public class EnemyHolder : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Start()
    {
        _player.SetEnemiesNumber(GetComponentsInChildren<Enemy>().Length);
    }
}
