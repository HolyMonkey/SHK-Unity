using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void Move(float x, float y)
    {
        float currentSpeed = _speed * Time.deltaTime;
        transform.Translate(x * currentSpeed, y * currentSpeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.Destroy();
        }
    }

    private IEnumerator ActivateSpeedBonus()
    {
        _speed *= 2;
        yield return new WaitForSeconds(2);
        _speed /= 2;
    }
}
