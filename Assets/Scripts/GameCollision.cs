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
            Enemy enemy = _enemyContainer.GetEnemies()[i];

            float distance = Vector3.Distance(_player.transform.position, enemy.transform.position);

            if (distance < _radius)
            {
                _enemyContainer.RemoveEnemy(enemy);
                _player.OnCollision(enemy);
            }
        }
    }
}
