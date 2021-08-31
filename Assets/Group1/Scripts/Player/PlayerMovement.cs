using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerObjectInteraction))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timerValue;
    [SerializeField] private float _speedModifier;

    private bool _isTimerActive;
    private float _time;
    private Rect _boundsRect;
    private PlayerObjectInteraction _interactor;

    private void Awake()
    {
        _interactor = GetComponent<PlayerObjectInteraction>();
        _boundsRect = GetBoundsRect();
    }

    private void OnEnable()
    {
        _interactor.SpeedBoosterPicked += OnSpeedBoosterPicked;
    }

    private void OnDisable()
    {
        _interactor.SpeedBoosterPicked += OnSpeedBoosterPicked;
    }

    private void Update()
    {
        CheckIsTimerActive();
    }

    public void TryMove(Vector2 direction)
    {
        var playerPosition = _speed * Time.deltaTime * direction + (Vector2)transform.position;

        if (_boundsRect.Contains(playerPosition))
            transform.Translate(_speed * Time.deltaTime * direction);
    }

    private Rect GetBoundsRect()
    {
        var bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        var spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
        var spriteHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2;
        var screenBounds = new Vector2(bounds.x + spriteWidth, bounds.y + spriteHeight);

        return new Rect(screenBounds, screenBounds * -2);
    }

    private void CheckIsTimerActive()
    {
        if (_isTimerActive)
        {
            _time -= Time.deltaTime;

            CheckTimeout();
        }
    }

    private void CheckTimeout()
    {
        if (_time < 0)
        {
            _isTimerActive = false;
            _speed /= _speedModifier;
        }
    }

    private void OnSpeedBoosterPicked()
    {
        _speed *= _speedModifier;
        _isTimerActive = true;
        _time = _timerValue;
    }
}