using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _health;
    
    private Vector3 moveVector;

    public event UnityAction<EnemyMover> EnemyDestroyed;

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");

        transform.position += moveVector * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<EnemyMover>(out EnemyMover enemy))
        {
            Destroy(enemy.gameObject);

            EnemyDestroyed?.Invoke(enemy);
        }
    }
}
