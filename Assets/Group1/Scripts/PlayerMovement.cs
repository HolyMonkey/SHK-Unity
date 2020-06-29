using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _acceleration;
    [SerializeField] private float _accelerationDuration;
    [SerializeField] private float _accelerationMultiply = 1;
    private Vector2 _direction = new Vector2();

    private void Update()
    {
        if (_accelerationDuration > 0)
        {
            _accelerationDuration -= Time.deltaTime;
            if(_accelerationDuration <= 0)
            {
                _accelerationMultiply = 1;
            }
        }

        _direction.x = Input.GetAxis("Horizontal");
        _direction.y = Input.GetAxis("Vertical");

        transform.Translate(_direction* _speed*_accelerationMultiply);
    }

    public void AddAcceleration()
    {
        _accelerationMultiply = 2;

        if (_accelerationDuration <= 0)
            _accelerationDuration = 2;
        else
            _accelerationDuration += 2;
    }
}
