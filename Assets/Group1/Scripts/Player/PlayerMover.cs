using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        transform.Translate(direction * _speed * Time.deltaTime);
    }

    private void OnEnable()
    {
        _player.SpeedBonusCaught += OnSpeedBonusCaught;
    }

    private void OnDisable()
    {
        _player.SpeedBonusCaught -= OnSpeedBonusCaught;
    }

    private void OnSpeedBonusCaught()
    {
        StartCoroutine(ActivateSpeedBonus());
    }

    private IEnumerator ActivateSpeedBonus()
    {
        _speed *= _player.SpeedBonus;

        yield return new WaitForSeconds(_player.DurationOfSpeedBonus);

        _speed /= _player.SpeedBonus;
    }
}
