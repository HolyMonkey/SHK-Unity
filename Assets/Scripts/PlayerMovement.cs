using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string HorizontalAxisName = "Horizontal";
    private const string VerticalAxisName = "Vertical";

    [SerializeField] private float _speedChangingValue = 2f;
    [SerializeField] private float _originSpeed = 4f;
    [SerializeField] private float _originTime = 5f;

    private float _currentSpeed;
    private float _currentTime;
    private EnemiesSpawner _enemiesSpawner;


    public void Init(EnemiesSpawner enemiesSpawner)
    {
        _enemiesSpawner = enemiesSpawner;
        _enemiesSpawner.EnemyDied += EnemyDied;
        _enemiesSpawner.AllEnemiesDied += AllEnemiesDied;
        _currentTime = _originTime;
        _currentSpeed = _originSpeed;
    }

    private void Update()
    {
        if (CanChangeSpeed())
        {
            _currentTime -= Time.deltaTime;
            if (_currentTime < 0)
            {
                SetCurrentSpeed(-_speedChangingValue);
                ResetCurrentTime();
            }
        }

        float horizontal = Input.GetAxis(HorizontalAxisName);
        float vertical = Input.GetAxis(VerticalAxisName);

        transform.Translate(horizontal * _currentSpeed * Time.deltaTime, vertical * _currentSpeed * Time.deltaTime, 0);
    }

    private void AllEnemiesDied()
    {
        _enemiesSpawner.EnemyDied -= EnemyDied;
        _enemiesSpawner.AllEnemiesDied -= AllEnemiesDied;
        enabled = false;
    }

    private void EnemyDied(EnemyHealth obj)
    {
        SetCurrentSpeed(_speedChangingValue);
        ResetCurrentTime();
    }

    private void SetCurrentSpeed(float speed)
    {
        _currentSpeed += speed;
    }

    private void ResetCurrentTime()
    {
        _currentTime = _originTime;
    }

    private bool CanChangeSpeed()
    {
        return _currentTime > 0 && _currentSpeed > 0;
    }
}