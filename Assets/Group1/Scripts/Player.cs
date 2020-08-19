using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _bonusTime = 3f;

    public event UnityAction<GameObject> EnemyCatched;

    private void Update()
    {
        float localSpeed = _speed * Time.deltaTime;
        float verticalAxis = Input.GetAxis("Vertical") * localSpeed;
        float horizontalAxis = Input.GetAxis("Horizontal") * localSpeed;

        transform.Translate(horizontalAxis, verticalAxis, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Enemy>(out Enemy enemy))
            EnemyCatched?.Invoke(enemy.gameObject);

        if (collision.TryGetComponent<SpeedBonus>(out SpeedBonus _speedBonus))
            StartCoroutine(CatchBonus(_speedBonus.gameObject));
    }

    private IEnumerator CatchBonus(GameObject bonus)
    {
        _speed *= 2;
        bonus.SetActive(false);

        yield return new WaitForSeconds(_bonusTime);

        _speed /= 2;
    }
}
