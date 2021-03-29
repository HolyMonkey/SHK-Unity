using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private int _speedMultiplier = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out SpeedBooster booster))
        {
            StartCoroutine(Booster(booster.Muliplier, booster.Duration));
        }
    }

    public void Move(Vector3 directon)
    {
        transform.position = transform.position + directon * _speed * _speedMultiplier * Time.deltaTime;
    }

    public IEnumerator Booster(int multyplier, float duration)
    {
        var waitForSeconds = new WaitForSeconds(duration);

        _speedMultiplier += multyplier;
        yield return waitForSeconds;
        _speedMultiplier -= multyplier;
    }
}
