using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private EnemiesContainer _enemiesContainer;
  
    private float _speed = 5;
    private float _coefficientOfSpeedChange = 2;

    private void OnEnable()
    {
        _enemiesContainer.PowerUpTimeStarted += GetIncreaseSpeed;
        _enemiesContainer.PowerUpTimeEnded += GetReduceSpeed;
    }

    private void OnDisable()
    {
        _enemiesContainer.PowerUpTimeStarted -= GetIncreaseSpeed;
        _enemiesContainer.PowerUpTimeEnded -= GetReduceSpeed;
    }

    private void Update()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        transform.position += moveDirection.normalized * _speed * Time.deltaTime;
    }

    private float IncreaseSpeed()
    {
        return _speed *= _coefficientOfSpeedChange;
    }

    private float ReduceSpeed()
    {
        if (_speed > 5)
        {
            _speed /= _coefficientOfSpeedChange;
        }
        return _speed;
    }

    private void GetIncreaseSpeed()
    {
        IncreaseSpeed();
    }
    private void GetReduceSpeed()
    {
        ReduceSpeed();
    }

    public void ResetSpeed()
    {
        _speed = 5;
    }
}