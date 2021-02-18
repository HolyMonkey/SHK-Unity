using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField] float _speedMultiplier = 2;
    [SerializeField] float _boostDuration = 3;

    public float Multiplier => _speedMultiplier;
    public float Duration => _boostDuration;
}
