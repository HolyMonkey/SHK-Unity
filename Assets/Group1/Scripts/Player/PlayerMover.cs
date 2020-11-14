using UnityEngine;

[RequireComponent(typeof(PlayerCollisionHandler))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Vector2 _axis;

    private PlayerCollisionHandler _collisionHandler;
    private bool _isBoostActive;
    private float _boostTime;
    private float _boostModifier = 1;

    private void Awake()
    {
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

        transform.Translate(_axis.x * _moveSpeed * _boostModifier * Time.deltaTime, _axis.y * _moveSpeed * _boostModifier * Time.deltaTime, 0);

        if (_isBoostActive)
        {
            _boostTime -= Time.deltaTime;
            if (_boostTime <= 0)
            {
                _boostModifier = 1;
                _isBoostActive = false;
            }
        }
    }

    private void OnBoostCollected(SpeedBooster booster)
    {
        _boostModifier = booster.BoostValue;
        _boostTime = booster.BoostTime;
        Destroy(booster.gameObject);
    }
}
