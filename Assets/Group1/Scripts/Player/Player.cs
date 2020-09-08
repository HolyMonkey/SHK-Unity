using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction<float, float> SpeedBonusCaught;

    public void CatchSpeedBonus(float speedChange, float duration)
    {
        SpeedBonusCaught?.Invoke(speedChange, duration);
    }
}
