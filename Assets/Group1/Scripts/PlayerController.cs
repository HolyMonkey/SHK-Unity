using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private EnvironmentTrigger _environmentTrigger;
    [SerializeField] private float _speed = 2;
    [SerializeField] private float _bonusRatio = 1;
    [SerializeField] private float _bonusDuration = 2;

    private void OnEnable()
    {
        _environmentTrigger.BonusCollecting += OnBonusCollecting;
    }

    private void OnDisable()
    {
        _environmentTrigger.BonusCollecting -= OnBonusCollecting;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * _speed * Time.deltaTime);
    }

    private void OnBonusCollecting()
    {
        float defaultSpeed = _speed;
        _speed += defaultSpeed * _bonusRatio;
        StartCoroutine(ReduceSpeed(defaultSpeed));
    }

    private IEnumerator ReduceSpeed(float defaultSpeed)
    {
        yield return new WaitForSeconds(_bonusDuration);
        _speed -= defaultSpeed * _bonusRatio;
    }
}