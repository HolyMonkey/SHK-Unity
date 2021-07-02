using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    [SerializeField] private float _speed;

    [SerializeField] private float _defaultSpeed;
    private Coroutine _coroutine;

    private void Start()
    {
        _defaultSpeed = _speed;
    }

    private void Update()
    {
        var horizontalInput = Input.GetAxis(Horizontal);
        var verticalInput = Input.GetAxis(Vertical);

        transform.Translate(horizontalInput * _speed * Time.deltaTime, verticalInput * _speed * Time.deltaTime, 0f);
    }

    public void Boost(float boostTime)
    {
        _speed += _defaultSpeed;

        _coroutine = StartCoroutine(StartChangeSpeed(boostTime));
        
    }

    private IEnumerator StartChangeSpeed(float boostTime)
    {
        yield return new WaitForSeconds(boostTime);

        _speed -= _defaultSpeed;

        if (_speed == _defaultSpeed)
        {
            StopCoroutine(_coroutine);
        }
            

        
    }
}
