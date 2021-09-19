using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Vector3 _targetDirection;
    private EnemySpawner _enemySpawner;

    private void Start()
    {
        ChooseDirection();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetDirection, _moveSpeed * Time.deltaTime);

        if (transform.position == _targetDirection)
            ChooseDirection();
    }

    private void ChooseDirection()
    {
        _targetDirection = Random.insideUnitCircle * 4;
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<CharectorMoving>())
        {
            other.GetComponent<CharectorMoving>().ActiveSpeedBoost();
            _enemySpawner.SubtractEnemy();
            Destroy(gameObject);
        }
    }

    public void Init(Transform enemySpawner)
    {
        _enemySpawner = enemySpawner.GetComponent<EnemySpawner>();
    }
}