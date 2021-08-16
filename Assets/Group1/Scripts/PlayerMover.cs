using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _movementX;
    private float _movementY;
    private bool _isMultiplied = false;

    public bool IsMultiplied => _isMultiplied;

    private void Update()
    {
        _movementX = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        _movementY = Input.GetAxis("Vertical") * _speed * Time.deltaTime;

        transform.Translate(_movementX, _movementY, 0);
    }

    public void MultiplySpeed(float value)
    {
        _speed *= value;
        _isMultiplied = true;
    }

    public void ShareSpeed(float value)
    {
        _speed /= value;
        _isMultiplied = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
            enemy.Die();
    }
}
