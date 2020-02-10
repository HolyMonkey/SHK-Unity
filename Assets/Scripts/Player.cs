using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _time;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector3(horizontal, vertical, 0) * (_speed * Time.deltaTime));
    }

    private void PickUpSpeedBoost(float speedMultyplier, float accelerationTime)
    {
        _speed *= speedMultyplier;
        _time = accelerationTime;
        StartCoroutine(TimerDecrease(speedMultyplier, accelerationTime));
    }

    public void OnCollision(Enemy enemy)
    {
        Destroy(enemy.gameObject);
    }

    private IEnumerator TimerDecrease(float speedMultyplier, float accelerationTime)
    {
        accelerationTime -= Time.deltaTime;
        if (accelerationTime < 0)
        {
            _speed /= speedMultyplier;
        }
        else
        {
            yield return null;
        }
    }
}
