using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private EndGame _endGame;
    [SerializeField] private float _speed;
    [SerializeField] private float _time;
    
    private bool _timerIsStop = false;

    private void Update()
    {
        if (_timerIsStop)
        {
            _speed = 0;
        }
        else
        {
            _time -= Time.deltaTime;

            if (_time < 0)
            {
                _timerIsStop = true;
            }

            if (Input.GetKey(KeyCode.W))
                transform.Translate(0, _speed * Time.deltaTime, 0);

            if (Input.GetKey(KeyCode.S))
                transform.Translate(0, _speed * Time.deltaTime * -1, 0);

            if (Input.GetKey(KeyCode.A))
                transform.Translate(_speed * Time.deltaTime * -1, 0, 0);

            if (Input.GetKey(KeyCode.D))
                transform.Translate(_speed * Time.deltaTime, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            _endGame.DestroyEnemy(collision.gameObject);
        }
    }
}
