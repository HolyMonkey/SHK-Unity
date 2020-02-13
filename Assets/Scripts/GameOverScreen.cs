using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private EnemyContainer _enemyContainer;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FinishGame()
    {
       _spriteRenderer.enabled = true;
    }

    private void OnEnable()
    {
        _enemyContainer.AllEnemiesDied += FinishGame;
    }

    private void OnDisable()
    {
        _enemyContainer.AllEnemiesDied -= FinishGame;
    }
}
