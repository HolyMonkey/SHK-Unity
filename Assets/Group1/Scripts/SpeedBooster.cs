using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : MonoBehaviour
{
    [SerializeField] private PlayerMover _player;
    [SerializeField] private float _multiplyValue;
    [SerializeField] private float _duration;

    private IEnumerator Boost()
    {
        _player.MultiplySpeed(_multiplyValue);

        yield return new WaitForSeconds(_duration);

        _player.ShareSpeed(_multiplyValue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMover player) && !_player.IsMultiplied)
        {
            StartCoroutine(Boost());
        }
    }
}
