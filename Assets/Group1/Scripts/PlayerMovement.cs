using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    public float Speed => _speed;

    private void Update()
    {

        float xDirection = Input.GetAxis("Horizontal");
        float yDirection = Input.GetAxis("Vertical");

        Vector3 direction = new Vector2(xDirection, yDirection);

        transform.position += direction * _speed * Time.deltaTime;
    }

    public void SetSpeed(float newSpeed)
    {
        _speed = newSpeed;
    }
}
