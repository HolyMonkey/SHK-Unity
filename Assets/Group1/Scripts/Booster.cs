using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : Enemy
{
    [SerializeField] private float _time;
    protected override void TakeDamage(PlayerMove playerMove)
    {
        playerMove.BoostSpeed(_time);
    }
}
