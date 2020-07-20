using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _acceleration;
    [SerializeField] private float _accelerationDuration = 2;
    [SerializeField] private float _accelerationMultiply = 1;
    private Vector2 _direction = new Vector2();
    private float _accelerationTime = 0;

    private void Update()
    {
        if (_accelerationMultiply > 1)
        {
            _accelerationTime += Time.deltaTime;
            if(_accelerationTime >= _accelerationDuration)
            {
                _accelerationMultiply /= 2;
                _accelerationTime = 0;
            }
        }

        _direction.x = Input.GetAxis("Horizontal");
        _direction.y = Input.GetAxis("Vertical");

        transform.Translate(_direction* _speed*_accelerationMultiply);
    }

    public void AddAcceleration()
    {
        _accelerationMultiply *= 2;
    }
}
