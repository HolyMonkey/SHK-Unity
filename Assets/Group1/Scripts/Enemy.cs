using UnityEngine;
using UnityEngine.Events;
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _distance = 4;
    [SerializeField] private float _speed = 2;
    private Vector3 _targetPosition;
    
    public bool Alive { get; private set; } = true;
    
    public event UnityAction Dead;

    private void Awake()
    {
        _targetPosition = GetNewPosition();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
        if (transform.position == _targetPosition)
            _targetPosition = GetNewPosition();
    }

    private Vector3 GetNewPosition()
    { 
        return Random.insideUnitCircle * _distance;
    }

    public void Die()
    {
        Alive = false;
        gameObject.SetActive(false);
        Dead?.Invoke();
    }
}
