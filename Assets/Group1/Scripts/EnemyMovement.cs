using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Vector3 _target;
    private float _targetRadius;

    private void Start()
    {
        FindNewTarget();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, 2 * Time.deltaTime);

        if (transform.position == _target)
        {
            FindNewTarget();
        }

    }

    private void FindNewTarget()
    {
        _target = Random.insideUnitCircle * _targetRadius;
    }
}
