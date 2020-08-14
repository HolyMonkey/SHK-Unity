using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _elapsedBonusTime = 0f;
    private float _bonusTime = 0f;

    public event UnityAction<Enemy> EnemyCatched;

    private void Update()
    {
        if(_bonusTime > 0f)
        {
            Debug.Log(_bonusTime);
            _elapsedBonusTime += Time.deltaTime;
        }

        if (_elapsedBonusTime > _bonusTime)
        {
            Debug.Log(_elapsedBonusTime);
            _bonusTime = 0f;
            _speed /= 2;
        }

        float localSpeed = _speed * Time.deltaTime;
        float verticalAxis = Input.GetAxis("Vertical") * localSpeed;
        float horizontalAxis = Input.GetAxis("Horizontal") * localSpeed;

        transform.Translate(horizontalAxis, verticalAxis, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Enemy>(out Enemy enemy))
            enemyCatched?.Invoke(enemy);

        if (collision.TryGetComponent<SpeedBonus>(out SpeedBonus _speedBonus))
        {
            if (_bonusTime == 0f)
            {
                _speed *= 2;
            }

            _bonusTime += _speedBonus.BonusTime;
            Destroy(_speedBonus.gameObject);
        }
    }
}
