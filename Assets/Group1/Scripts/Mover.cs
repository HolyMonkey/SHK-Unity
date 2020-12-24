using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Translate(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * _speed * Time.deltaTime);
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
