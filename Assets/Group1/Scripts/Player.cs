using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    public bool timer;
    public float time;

    private void Update(){
        if (timer)
        {
            time -= Time.deltaTime;
            if(time < 0)
            {
                timer = false;
                _speed /= 2;
            }
        }

        if (Input.GetKey(KeyCode.W))
            transform.Translate(0, _speed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(0, -_speed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.A))
            transform.Translate(-_speed * Time.deltaTime, 0, 0);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(_speed * Time.deltaTime, 0, 0);
    }

    public void SendMEssage(GameObject b)
    {


        if(b.name == "enemy")
        {
            Destroy(b);
        }if(b.name == "speed")
        {
            _speed *= 2;
            timer = true;
            time = 2;



        }
    }
}
