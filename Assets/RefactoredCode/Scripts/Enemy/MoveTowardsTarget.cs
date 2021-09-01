using UnityEngine;

public class MoveTowardsTarget : MonoBehaviour
{
    [SerializeField] private float _circleRangeAroundTarget;
    [SerializeField] private float _targetDistanceDelta;

    private Vector3 _target;

    private void Start()
    {
        FindNewTarget(_circleRangeAroundTarget);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _targetDistanceDelta * Time.deltaTime);

        if (transform.position == _target)
            FindNewTarget(_circleRangeAroundTarget);
    }

    private void FindNewTarget(float circleRange)
    {
        _target = Random.insideUnitCircle * circleRange;
    }
}
