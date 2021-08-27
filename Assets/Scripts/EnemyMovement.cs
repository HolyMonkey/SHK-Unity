using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _maxDistanceDelta = 2f;
    [SerializeField] private float _randomOffset = 4f;
    [SerializeField] private float _minDistance = 0.2f;

    private Vector3 _targetPosition;
    private EnemyHealth _enemyHealth;

    public void Init()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
        UpdateTargetPosition();
    }

    private void Update()
    {
        if (transform.position == _targetPosition)
            UpdateTargetPosition();
        
        transform.position =
            Vector3.MoveTowards(transform.position, _targetPosition, _maxDistanceDelta * Time.deltaTime);
    }

    private void UpdateTargetPosition()
    {
        _targetPosition = Random.insideUnitCircle * _randomOffset;
    }
}