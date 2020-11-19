using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerCollisionHandler))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Vector2 _axis;

    private PlayerCollisionHandler _collisionHandler;
    private float _boostTime;
    private float _boostModifier = 1;

    private void Awake()
    {
        StartCoroutine(BoostMoveSpeed());
        _collisionHandler = GetComponent<PlayerCollisionHandler>();
    }

    private void OnEnable()
    {
        _collisionHandler.BoostCollected += OnBoostCollected;
    }

    private void OnDisable()
    {
        _collisionHandler.BoostCollected -= OnBoostCollected;
    }

    private void Update()
    {
        _axis.x = Input.GetAxis("Horizontal");
        _axis.y = Input.GetAxis("Vertical");

        transform.Translate(_axis.x * _moveSpeed * _boostModifier * Time.deltaTime,
                            _axis.y * _moveSpeed * _boostModifier * Time.deltaTime, 0);

    }

    private void OnBoostCollected(SpeedBooster booster)
    {
        _boostTime = booster.BoostTime;
        _boostModifier = booster.BoostValue;
    }

    private IEnumerator BoostMoveSpeed()
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            _boostTime -= Time.fixedDeltaTime;

            if (_boostTime < 0)
                _boostModifier = 1;
        }
    }
}
