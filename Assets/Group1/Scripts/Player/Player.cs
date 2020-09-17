using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speedBonus;
    [SerializeField] private float _durationOfSpeedBonus;

    public float SpeedBonus => _speedBonus;
    public float DurationOfSpeedBonus => _durationOfSpeedBonus;

    public event UnityAction SpeedBonusCaught;

    public void CatchSpeedBonus()
    {
        SpeedBonusCaught?.Invoke();
    }
}
