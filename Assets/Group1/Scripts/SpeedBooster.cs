using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : MonoBehaviour
{
    [SerializeField] private float _multiplier;
    [SerializeField] private float _duration;

    public float Multiplier => _multiplier;
    public float Duration => _duration;
}
