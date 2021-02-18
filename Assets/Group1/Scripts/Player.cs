using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 2;

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
            StartCoroutine(BoostSpeed(boost.Multiplier, boost.Duration));
    }

    public IEnumerator BoostSpeed(float multiplier, float duration)
    {
        _speed *= multiplier;
        yield return new WaitForSeconds(duration);
        _speed /= multiplier;
    }
}
