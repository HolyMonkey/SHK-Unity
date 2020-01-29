using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _time;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(0, _speed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(0, -_speed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.A))
            transform.Translate(-_speed * Time.deltaTime, 0, 0);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(_speed * Time.deltaTime, 0, 0);
    }

    private void PickUpSpeedBoost(float speedMultyplier, float accelerationTime)
    {
        _speed *= speedMultyplier;
        _time = accelerationTime;
        StartCoroutine(TimerDecrease(speedMultyplier));
    }

    public void OnCollision(Enemy enemy)
    {
        Destroy(enemy.gameObject);
    }

    private IEnumerator TimerDecrease(float speedMultyplier)
    {
        _time -= Time.deltaTime;
        if (_time < 0)
        {
            _speed /= speedMultyplier;
        }
        else
        {
            yield return null;
        }
    }
}
