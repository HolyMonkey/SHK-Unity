using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Player _player;
    private Vector2 _direction;


    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        _direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    private void OnEnable()
    {
        _player.SpeedBonusCaught += OnSpeedBonusCaught;
    }

    private void OnDisable()
    {
        _player.SpeedBonusCaught -= OnSpeedBonusCaught;
    }

    private void OnSpeedBonusCaught(float speedChange, float duration)
    {
        StartCoroutine(ActivateSpeedBonus(speedChange, duration));
    }

    private IEnumerator ActivateSpeedBonus(float speedChange, float duration)
    {
        _speed *= speedChange;

        yield return new WaitForSeconds(duration);

        _speed /= speedChange;
    }
}
