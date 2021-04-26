using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _defaultSpeed;
    private Coroutine _coroutine;
    private Vector2 _move;
    private PlayerInput _input;

    private void Start()
    {
        _defaultSpeed = _speed;
        _input = new PlayerInput();
        _input.Enable();
    }

    private void Update()
    {
        _move = _input.PlayerControl.Move.ReadValue<Vector2>();
        OnMove(_move);
    }

    private void OnMove(Vector2 move)
    {
        transform.position += new Vector3(move.x, move.y, 0) *_speed * Time.deltaTime;
    }

    public void BoostSpeed(float boostTime)
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
        while (_speed!=_defaultSpeed)
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
