using UnityEngine;

public class SpeedAccselerator : MonoBehaviour
{
    [SerializeField] private PlayerController _player;

    private int _speedIncreaseMultiplier = 2;
    private int _baseIncreaseMultiplier = 2;
    private int _speedBonusesAmount = 1;

    private void OnEnable()
    {
        _player.SpeedAccselerating += OnSpeedAccselerating;
        _player.SpeedAccselerationTimerPassed += OnSpeedAccselerationTimerPassed;
    }

    private void OnDisable()
    {
        _player.SpeedAccselerating -= OnSpeedAccselerating;
        _player.SpeedAccselerationTimerPassed -= OnSpeedAccselerationTimerPassed;
    }

    private int OnSpeedAccselerating()
    {
        if (_speedBonusesAmount == 1)
        {
            _speedBonusesAmount++;

            return _speedIncreaseMultiplier;
        }
        else
        {
            _speedBonusesAmount++;
            _speedIncreaseMultiplier++;

            return  _speedIncreaseMultiplier;
        }
    }

    private int OnSpeedAccselerationTimerPassed()
    {
        if (_speedBonusesAmount > 1)
        {
            _speedBonusesAmount--;

            if (_speedIncreaseMultiplier > _baseIncreaseMultiplier)
            {
                _speedIncreaseMultiplier--;
            }

            return  _speedIncreaseMultiplier;
        }
        else
        {
            return _speedIncreaseMultiplier / _speedIncreaseMultiplier;
        }
    }
}
