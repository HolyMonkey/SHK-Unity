using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private GameObject _menu;
    [SerializeField] private Rigidbody2D _rigidbody;

    private int _killedEnemies = 0;
    private int _startEnemiesNumber;

    private void Update()
    {
        _rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * _moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            _killedEnemies++;

            if (_killedEnemies >= _startEnemiesNumber)
            {
                _menu.SetActive(true);
                enabled = false;
            }

            Destroy(gameObject);
        }
    }

    public void SetEnemiesNumber(int enemiesNumber)
    {
        _startEnemiesNumber = enemiesNumber;
    }

    public IEnumerator BoostSpeed(float duration, float multiplier)
    {
        _moveSpeed *= multiplier;

        yield return new WaitForSeconds(duration);

        _moveSpeed /= multiplier;
    }
}
