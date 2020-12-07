using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _checkRadius;

    private Vector2 _direction;

    public float CheckRadius => _checkRadius;

    private void Update()
    {
        _direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Move(_direction);
    }

    private void Move(Vector2 direction)
    {
        float currentSpeed = _speed * Time.deltaTime;
        transform.Translate(direction * currentSpeed);
    }

    public void DoubleCheckRadius()
    {
        _checkRadius *= 2;
    }
}
