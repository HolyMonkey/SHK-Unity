using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Collector _collector;
    [SerializeField] private Color _targetAlpha;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _collector.AllEnemyDied += OnAllEnemyDied;
    }

    private void OnDisable()
    {
        _collector.AllEnemyDied -= OnAllEnemyDied;
    }

    private void OnAllEnemyDied()
    {
        Time.timeScale = 0;
        _spriteRenderer.color = _targetAlpha;
    }
}
