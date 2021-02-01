using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerCollisionHandler : MonoBehaviour
{
    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Enemy enemy))
        {
            enemy.Dying();
            Destroy(enemy.gameObject);
        }

        if (collider.TryGetComponent(out SpeedBooster speedBooster))
        {
            _player.PickUpSpeedBooster(speedBooster.BoostMultiplier);
            Destroy(speedBooster.gameObject);
        }
    }
}
