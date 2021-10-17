using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private EnemyContainer _enemyContainer;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.transform.parent.TryGetComponent<Enemy>(out _))
        {
            Destroy(collision.collider.transform.parent.gameObject);

            _enemyContainer.TryEndLevel();
        }

        if (collision.collider.transform.parent.TryGetComponent<Speed>(out _))
        {
            transform.parent.GetComponent<PlayerController>().IncreaseSpeed();

            Destroy(collision.collider.transform.parent.transform.gameObject);
        }
    }
}
