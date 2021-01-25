using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 2;

    private float _defaultSpeed;
    private Coroutine _boostResetCoroutine;

    private void Awake()
    {
        _defaultSpeed = _speed;
    }

    private void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0).normalized;
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
            enemy.Die();

        if (collision.TryGetComponent(out SpeedBoost boost))
            BoostSpeed(boost.Multiplier, boost.Duration);
    }

    private IEnumerator ResetSpeed(float delay)
    {
        yield return new WaitForSeconds(delay);
        _speed = _defaultSpeed;
        _boostResetCoroutine = null;
    }

    private void BoostSpeed(float multiplier, float duration)
    {
        if (_boostResetCoroutine != null)
            StopCoroutine(_boostResetCoroutine);

        _speed = _defaultSpeed * multiplier;
        _boostResetCoroutine = StartCoroutine(ResetSpeed(duration));
    }
}
