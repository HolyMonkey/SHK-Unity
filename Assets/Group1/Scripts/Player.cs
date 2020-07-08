using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
            Move(0, 1);
        if (Input.GetKey(KeyCode.S))
            Move(0, -1);
        if (Input.GetKey(KeyCode.A))
            Move(-1, 0);
        if (Input.GetKey(KeyCode.D))
            Move(1, 0);
    }

    private void Move(float x, float y)
    {
        transform.Translate(x * _speed * Time.deltaTime, y * _speed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.Destroy();
        }
    }

    private IEnumerator ActivateSpeedBonusCoroutine()
    {
        _speed *= 2;
        yield return new WaitForSeconds(2);
        _speed /= 2;
    }
}
