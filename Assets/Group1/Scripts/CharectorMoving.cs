using System.Collections;
using UnityEngine;

public class CharectorMoving : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _boostDuration;

    private float _boostTimer;
    private Coroutine _currentCoroutine;

    private void Update()
    {
        transform.position += new Vector3(0, _moveSpeed * Time.deltaTime, 0) * Input.GetAxis("Vertical");
        transform.position += new Vector3(_moveSpeed * Time.deltaTime, 0, 0) * Input.GetAxis("Horizontal");
    }

    private IEnumerator ActiveSpeedBoostTimer()
    {
        while (_boostTimer > 0f)
        {
            _boostTimer -= 1 * Time.deltaTime;
            yield return null;
        }

        _moveSpeed /= 2;
    }

    public void ActiveSpeedBoost()
    {
        if (_boostTimer <= 0)
            _moveSpeed *= 2;

        _boostTimer = _boostDuration;

        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(ActiveSpeedBoostTimer());
    }
}