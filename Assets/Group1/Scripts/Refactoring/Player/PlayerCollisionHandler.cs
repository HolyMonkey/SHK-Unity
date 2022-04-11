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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.Dying();
        }

        if (collision.TryGetComponent(out SpeedBooster speedBooster))
        {
            _player.PickUpBooster(speedBooster.SpeedMultiplier, speedBooster.BoosterDuration);
            Destroy(speedBooster);
        }
    }
}
