using UnityEngine;

public class SpeedBooster : MonoBehaviour
{
    [SerializeField] private float _speedMultiplier;
    [SerializeField] private float _boosterDuration;

    public float SpeedMultiplier => _speedMultiplier;
    public float BoosterDuration => _boosterDuration;
}
