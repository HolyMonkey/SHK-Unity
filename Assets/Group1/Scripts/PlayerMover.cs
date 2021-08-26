using System.Collections;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxBoostedSpeedTime;

    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    private void Update()
    {
        float deltaX = GetDirection(Horizontal);
        float deltaY = GetDirection(Vertical);

        transform.Translate(deltaX, deltaY, 0);
    }

    public void IncreaseSpeed()
    {
        StartCoroutine(ResetSpeed());
    }

    private float GetDirection(string axis)
    {
        return Input.GetAxis(axis) * _speed * Time.deltaTime;
    }

    private IEnumerator ResetSpeed()
    {
        _speed += _speed;

        yield return new WaitForSeconds(_maxBoostedSpeedTime);

        _speed -= _speed;
    }
}
