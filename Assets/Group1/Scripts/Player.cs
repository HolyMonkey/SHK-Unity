﻿using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5;

    private void Update()
    {
        var offset = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.Translate(offset * _speed * Time.deltaTime);
    }
}
