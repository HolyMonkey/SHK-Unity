using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    public float Speed => _speed;

    private void Update()
    {

        float xDir = Input.GetAxis("Horizontal");
        float yDir = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector2(xDir, yDir);

        transform.position += moveDirection * _speed * Time.deltaTime;
    }

    public void SetSpeed(float newSpeed)
    {
        _speed = newSpeed;
    }
}
