using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] private Vector3 _endPathPoint;
    [SerializeField] private float _radius = 4;
    [SerializeField] private float _speed = 2;

    private void Start()
    {
        _endPathPoint = GetRandomPathPoint();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _endPathPoint, _speed * Time.deltaTime);
        if (transform.position == _endPathPoint)
            _endPathPoint = GetRandomPathPoint();
    }

    private Vector3 GetRandomPathPoint()
    {
        return Random.insideUnitCircle * _radius;
    }
}
