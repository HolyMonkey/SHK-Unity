using UnityEngine;

public class SpeedAccselerator : MonoBehaviour
{
    [SerializeField] private PlayerController _player;

    private int _speedIncreaseMultiplier = 2;

    private void OnEnable()
    {
        _player.SpeedAccselerating += OnSpeedAccselerating;
    }

    private void OnDisable()
    {
        _player.SpeedAccselerating -= OnSpeedAccselerating;
    }

    private float OnSpeedAccselerating(float speed)
    {
        return speed * _speedIncreaseMultiplier;
    }
}
