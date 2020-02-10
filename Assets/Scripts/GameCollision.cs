using UnityEngine;

public class GameCollision : MonoBehaviour
{
    [SerializeField] private EnemyContainer _enemyContainer;
    [SerializeField] private float _radius;
    [SerializeField] private Player _player;

    private void Update()
    {
        for (int i = _enemyContainer.GetEnemies().Count - 1; i >= 0; i--)
        {
            float distance;

            distance = Vector3.Distance(_player.transform.position, _enemyContainer.GetEnemies()[i].transform.position);
            if (distance < _radius)
            {
                Enemy enemy = _enemyContainer.GetEnemies()[i];
                _enemyContainer.RemoveEnemy(enemy);
                _player.OnCollision(enemy);
            }
        }
    }
}
