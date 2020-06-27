using UnityEngine;
using System.Collections;

public class CircleMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _acceleration;
    [SerializeField] private float _accelerationDuration;
    private Vector2 _direction = new Vector2();

    void Update()
    {
        if (_acceleration)
        {
            _accelerationDuration -= Time.deltaTime;
            if(_accelerationDuration < 0)
            {
                _acceleration = false;
                _speed /= 2;
            }
        }

        _direction.x = Input.GetAxis("Horizontal")*_speed;
        _direction.y = Input.GetAxis("Vertical")*_speed;

        transform.Translate(_direction);
    }

    public void AddAcceleration()
    {
        _speed *= 2;
        _acceleration = true;
        _accelerationDuration = 2;
    }
}
