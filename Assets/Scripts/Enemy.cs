using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _newTargetRadius = 4;
    [SerializeField] private float _speed = 2;

    private EnemyCounter _enemyCounter;
    private Vector3 _target;
    private bool _isBoostBonus;

    public void Init(EnemyCounter enemyCounter)
    {
        _enemyCounter = enemyCounter;
        _enemyCounter.EnemyAdd(this);
    }

    private void Start()
    {
        _isBoostBonus = Random.Range(0, 2) == 1;
        _target = Random.insideUnitCircle * _newTargetRadius;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        if (transform.position == _target)
            _target = Random.insideUnitCircle * _newTargetRadius;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player;

        if (collision.gameObject.TryGetComponent(out player))
        {
            if(_isBoostBonus)
                player.Boost();

            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        _enemyCounter.EnemyDown(this);
    }
}
