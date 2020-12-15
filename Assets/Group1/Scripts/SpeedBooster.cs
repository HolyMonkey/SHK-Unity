using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpeedBooster : MonoBehaviour
{
    [SerializeField] private float _boostTime;

    public event UnityAction<float, float> SpeedBoost;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            SpeedBoost?.Invoke(enemy.SpeedBoost, _boostTime);
        }
    }
}
