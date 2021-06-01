using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    [SerializeField] private float _speed;

    private float _defaultSpeed;
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
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(StartChangeSpeed(boostTime));
        }
    }

    private IEnumerator StartChangeSpeed(float boostTime)
    {
        var waitForOneSeconds = new WaitForSeconds(boostTime);
        while (_speed != _defaultSpeed)
        {
            yield return waitForOneSeconds;
            _speed -= _defaultSpeed;
        }
        EndChangeSpeed(_coroutine);
    }

    private void EndChangeSpeed(Coroutine coroutine)
    {
        StopCoroutine(coroutine);
        _coroutine = null;
    }
}
