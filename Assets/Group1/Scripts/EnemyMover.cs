using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private int _radius;
    [SerializeField] private float _speed;

    private Vector3 _target;

    private void Start()
    {
        PasteRandomTarget();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        if (transform.position == _target)
            PasteRandomTarget();
    }

    private void PasteRandomTarget()
    {
        _target = Random.insideUnitCircle * _radius;
    }
}
