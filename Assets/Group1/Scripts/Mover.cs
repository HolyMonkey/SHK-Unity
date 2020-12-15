using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpeedBooster))]

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private SpeedBooster _speedBooster;

    private void Update()
    {
        transform.Translate(new Vector2(Input.GetAxis("Horizontal") * _speed * Time.deltaTime, Input.GetAxis("Vertical") * _speed * Time.deltaTime));
    }

    private void OnSpeedBoost(float speedBoost, float timeBoost)
    {
        StartCoroutine(BoostSpeed(speedBoost, timeBoost));
    }

    private IEnumerator BoostSpeed(float speedBoost, float timeBoost)
    {
        _speed *= speedBoost;
        yield return new WaitForSeconds(timeBoost);
        _speed /= speedBoost;
    }

    private void OnEnable()
    {
        _speedBooster.SpeedBoost += OnSpeedBoost;
    }

    private void OnDisable()
    {
        _speedBooster.SpeedBoost -= OnSpeedBoost;
    }
}
