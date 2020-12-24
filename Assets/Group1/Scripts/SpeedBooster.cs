using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : Follower
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            StartCoroutine(player.BoostSpeed(player.BoostSpeedTime));
        }
    }
}
