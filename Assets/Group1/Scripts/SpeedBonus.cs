using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBonus : MonoBehaviour
{
    [SerializeField] private float _speedChange;
    [SerializeField] private float _duration;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            player.CatchSpeedBonus(_speedChange, _duration);

            Destroy(gameObject);
        }
    }
}
