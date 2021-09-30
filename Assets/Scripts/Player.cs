using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _boostTime;

    public void Boost()
    {
        StartCoroutine(BoostCoroutine());
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 moveVector = Vector2.zero;
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");

        transform.Translate(moveVector * _speed * Time.deltaTime);
    }

    private IEnumerator BoostCoroutine()
    {
        _speed *= 2;
        yield return new WaitForSecondsRealtime(_boostTime);
        _speed /= 2;
    }
}
