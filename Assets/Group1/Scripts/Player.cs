using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Rigidbody2D _rigidbody;

    private void Update()
    {
        _rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * _moveSpeed;
    }

    public IEnumerator BoostSpeed(float duration, float multiplier)
    {
        _moveSpeed *= multiplier;

        yield return new WaitForSeconds(duration);

        _moveSpeed /= multiplier;
    }
}
