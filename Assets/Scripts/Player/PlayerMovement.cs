using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _speed = 5;
    private float _coefficientOfSpeedChange = 2;

    private void Update()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        transform.position += moveDirection.normalized * _speed * Time.deltaTime;
    }

    private void IncreaseSpeed()
    {
        _speed *= _coefficientOfSpeedChange;
        StartCoroutine(LaunchPowerUpTimeCountDown());
    }
   
    private void ResetSpeed()
    {
        _speed = 5;
    }

    public IEnumerator LaunchPowerUpTimeCountDown()
    {
        yield return new WaitForSeconds(3);
        if (_speed > 5)
        {
            _speed /= _coefficientOfSpeedChange;
        }
    }

    private void ResetPosition()
    {
        gameObject.transform.position = new Vector3(0, 0, 0);
    }

    public void Reset()
    {
        ResetPosition();
        ResetSpeed();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PowerUp powerUp))
        {
            IncreaseSpeed();
        }
    }
}