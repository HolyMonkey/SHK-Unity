using UnityEngine;

public class SpeedAccselerator : MonoBehaviour
{
    [SerializeField] private PlayerController _player;

    private int _speedIncreaseMultiplier = 2;

    private void OnEnable()
    {
        _player.AccseleratingSpeed += IncreaseSpeed;
    }

    private void OnDisable()
    {
        _player.AccseleratingSpeed -= IncreaseSpeed;
    }

    private float IncreaseSpeed(float speed)
    {
        return speed * _speedIncreaseMultiplier;
    }
}
