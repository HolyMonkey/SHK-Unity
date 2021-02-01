using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : MonoBehaviour
{
    [SerializeField] private float _boostMultiplier;

    public float BoostMultiplier => _boostMultiplier;
}
