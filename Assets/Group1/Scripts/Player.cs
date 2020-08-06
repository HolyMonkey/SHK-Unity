using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _elapsedBonusTime;

    public event UnityAction<Enemy> enemyCatched;

    public bool _bonus = false;
    public float _bonusTime = 2f;

    private void Update()
    {
        if (_bonus)
        {
            _elapsedBonusTime += Time.deltaTime;
            if (_elapsedBonusTime >= _bonusTime)
            {
                _elapsedBonusTime = 0;
                _bonus = false;
                _speed /= 2;
            }
        }

        float verticalAxis = Input.GetAxis("Vertical") * _speed * Time.deltaTime;
        float horizontalAxis = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;

        if(verticalAxis !=0 || horizontalAxis != 0)
        {
            transform.Translate(horizontalAxis, verticalAxis, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Enemy>(out Enemy enemy))
            enemyCatched?.Invoke(enemy);

        if (collision.TryGetComponent<SpeedBonus>(out SpeedBonus _speedBonus))
        {
            Destroy(_speedBonus.gameObject);
            _speed *= 2;
            _bonus = true;

        }
    }
}
