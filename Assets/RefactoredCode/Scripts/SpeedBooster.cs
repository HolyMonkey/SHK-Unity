using UnityEngine;

public class SpeedBooster : MonoBehaviour
{
    [SerializeField] private float _speedBoostModifier;
    [SerializeField] private float _speedBoostTime;

    public float SpeedBoostModifier => _speedBoostModifier;
    public float SpeedBoostTime => _speedBoostTime;
}
