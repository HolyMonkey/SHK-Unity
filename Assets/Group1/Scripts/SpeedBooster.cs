using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : MonoBehaviour
{
    [SerializeField] private float _speedBoost;
    [SerializeField] private float _boostTime;

    public float SpeedBoost => _speedBoost;
    public float BoostTime => _boostTime;

}
