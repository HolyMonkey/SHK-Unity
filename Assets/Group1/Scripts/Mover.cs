using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _xSpeed;
    private float _ySpeed;

    private void Update()
    {
        _xSpeed = Input.GetAxis("Horizontal") * _speed;
        _ySpeed = Input.GetAxis("Vertical") * _speed;
        transform.Translate(new Vector2(_xSpeed, _ySpeed) *  Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<SpeedBooster>(out SpeedBooster speedBooster))
        {
            Boost(speedBooster.SpeedBoost, speedBooster.BoostTime);
        }
    }
    private void Boost(float speedBoost, float timeBoost)
    {
        StartCoroutine(BoostSpeed(speedBoost, timeBoost));
    }

    private IEnumerator BoostSpeed(float speedBoost, float timeBoost)
    {
        _speed *= speedBoost;
        yield return new WaitForSeconds(timeBoost);
        _speed /= speedBoost;
    }
}
