using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class SpeedBooster : MonoBehaviour
{
    [SerializeField] private float _boostDuration;
    [SerializeField] private float _boostSpeedMultiplier;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            StartCoroutine(player.BoostSpeed(_boostDuration, _boostSpeedMultiplier));

            Destroy(gameObject);
        }
    }
}
