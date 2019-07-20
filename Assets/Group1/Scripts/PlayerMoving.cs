using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _timer;
    [SerializeField] private float _time;

    void Update(){
        if (_timer)
        {
            SubtractBountyTime(Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.W))
            transform.Translate(0, _speed * Time.deltaTime, 0);
        else if (Input.GetKey(KeyCode.S))
            transform.Translate(0, -_speed * Time.deltaTime, 0);
        else if (Input.GetKey(KeyCode.A))
            transform.Translate(-_speed * Time.deltaTime, 0, 0);
        else if (Input.GetKey(KeyCode.D))
            transform.Translate(_speed * Time.deltaTime, 0, 0);
    }

    public void EndGame()
    {
        enabled = false;
    }

    private void SubtractBountyTime(float time)
    {
        _time -= time;
        if (_time < 0)
        {
            _speed /= 2;
            _timer = false;
        }
    }
}
