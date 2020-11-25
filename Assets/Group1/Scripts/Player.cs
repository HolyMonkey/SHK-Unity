using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _checkRadius;

    public float CheckRadius => _checkRadius;

    private void Update()
    {
        Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void Move(float axisX, float axisY)
    {
        float currentSpeed = _speed * Time.deltaTime;
        transform.Translate(axisX * currentSpeed, axisY * currentSpeed, 0);
    }

    public void DoubleCheckRadius()
    {
        _checkRadius *= 2;
    }
}
