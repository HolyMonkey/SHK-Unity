using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float _speed = 4f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector2.up * _speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector2.down * _speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector2.left * _speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }
}
