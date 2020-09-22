using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CircleCollider2D))]

public class Enemy : MonoBehaviour
{
  [SerializeField] private float _speed = 2f;
  [SerializeField] private float _circleColliderRadius = 0.2f;
  [SerializeField] private int _nextWaypointRadius = 4;

  public event UnityAction<Enemy> Dying;

  private Vector3 _nextWaypoint;
  private CircleCollider2D _collider2D;

  private void Start()
  {
    SetNextWaypoint();
    _collider2D = GetComponent<CircleCollider2D>();
    _collider2D.radius = _circleColliderRadius;
    _collider2D.isTrigger = true;
  }

  private void Update()
  {
    transform.position = Vector3.MoveTowards(transform.position, _nextWaypoint, _speed * Time.deltaTime);

    if (transform.position == _nextWaypoint)
      SetNextWaypoint();
  }

  private void SetNextWaypoint()
  {
    _nextWaypoint = Random.insideUnitCircle * _nextWaypointRadius;
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.GetComponent<Player>() != null)
    {
      Destroy(gameObject);
      Dying?.Invoke(this);
    }
  }
}
