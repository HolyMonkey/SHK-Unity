using UnityEngine;

public class EnemyMoving: MonoBehaviour
{
    private Vector3 _enemyTarget;
    [SerializeField] private int _speedEnemyMoving;

    void Start()
    {
        _enemyTarget = Random.insideUnitCircle * 4;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _enemyTarget, _speedEnemyMoving * Time.deltaTime);
        if (Vector2.Distance(transform.position, _enemyTarget) < 0.1f)
            _enemyTarget = Random.insideUnitCircle * 4;
    }
}
