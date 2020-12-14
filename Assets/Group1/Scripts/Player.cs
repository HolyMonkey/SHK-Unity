using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _boostTime;
    [SerializeField] private float _speedBoost;

    public event UnityAction DestroiedEnemy;

    private void Update()
    {
        transform.Translate(new Vector2(Input.GetAxis("Horizontal") * _speed * Time.deltaTime, 0));
        transform.Translate(new Vector2(0, Input.GetAxis("Vertical") * _speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            if(collision.TryGetComponent<Speed>(out Speed speed))
            {
                StartCoroutine(BoostSpeed(_boostTime));
            }

            Destroy(enemy.gameObject);

            DestroiedEnemy?.Invoke();
        }
    }

    private IEnumerator BoostSpeed(float timeBoost)
    {
        _speed *= _speedBoost;
        yield return new WaitForSeconds(timeBoost);
        _speed /= _speedBoost;
    }
}
