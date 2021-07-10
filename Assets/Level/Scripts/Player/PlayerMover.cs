using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";
    [SerializeField] private float _speed;

    public float Speed { get => _speed; set => _speed = value; }

    private void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis(HorizontalAxis), Input.GetAxis(VerticalAxis), 0);
        transform.Translate(movement * Time.deltaTime * Speed);
    }
}
