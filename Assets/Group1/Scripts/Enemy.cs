using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Follower
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.PlusKilledEnemies();
            Destroy(gameObject);
        }
    }
}
