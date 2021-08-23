using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public class EnemyMovement : MonoBehaviour
{
    private Vector3 _moveTarget;
    private Transform _player;
    private EnemyHealth _enemyHealth;
        
    [SerializeField] private float _maxDistanceDelta = 2f;
    [SerializeField] private float _randomOffset = 4f;
    [SerializeField] private float _minDistance = 0.2f;
        
    public void Init(Transform player)
    {
        _enemyHealth = GetComponent<EnemyHealth>();
        _moveTarget = Random.insideUnitCircle * _randomOffset;
        _player = player;
    }

    private void Update()
    {
        if (transform.position == _moveTarget)
            _moveTarget = Random.insideUnitCircle * _randomOffset;
        else
            transform.position =
                Vector3.MoveTowards(transform.position, _moveTarget, _maxDistanceDelta * Time.deltaTime);

        if (_player != null)
        {
            if (Vector3.Distance(_player.position, transform.position) < _minDistance)
            {
                _enemyHealth.Die();
            }
        }
    }
}