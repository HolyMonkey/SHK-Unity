using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string HorizontalAxisName = "Horizontal";
    private const string VerticalAxisName = "Vertical";
    
    private float _currentTime;
    private EnemiesSpawner _enemiesSpawner;

    [SerializeField] private float _speed = 4f;
    [SerializeField] private bool _hasMaxSpeed = true;
    [SerializeField] private float _originTime = 2f;

    public void Init(EnemiesSpawner enemiesSpawner)
    {
        _enemiesSpawner = enemiesSpawner;
        _enemiesSpawner.OnEnemyDied += OnEnemyDied;
        _enemiesSpawner.OnAllEnemiesDied += OnAllEnemiesDied;
        _currentTime = _originTime;
    }

    private void Update()
    {
        if (_hasMaxSpeed)
        {
            _currentTime -= Time.deltaTime;
            if (_currentTime < 0)
            {
                _hasMaxSpeed = false;
                _speed /= 2;
            }
        }
        
        float horizontal = Input.GetAxis(HorizontalAxisName);
        float vertical = Input.GetAxis(VerticalAxisName);

        transform.Translate(horizontal * _speed * Time.deltaTime, vertical * _speed * Time.deltaTime, 0);
    }

    private void OnAllEnemiesDied()
    {
        _enemiesSpawner.OnEnemyDied -= OnEnemyDied;
        _enemiesSpawner.OnAllEnemiesDied -= OnAllEnemiesDied;
        enabled = false;
    }

    private void OnEnemyDied(EnemyHealth obj)
    {
        if (!_hasMaxSpeed)
        {
            ResetSpeed();
        }
    }

    private void ResetSpeed()
    {
        _speed *= 2;
        _hasMaxSpeed = true;
        _currentTime = _originTime;
    }
}