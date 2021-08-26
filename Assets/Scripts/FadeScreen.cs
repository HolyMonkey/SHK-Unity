using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FadeScreen : MonoBehaviour
{
    [SerializeField] private EnemiesSpawner _enemiesSpawner;
    
    private SpriteRenderer _spriteRenderer;
    
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _enemiesSpawner.AllEnemiesDied += ShowFade;
    }

    private void OnDisable()
    {
        _enemiesSpawner.AllEnemiesDied -= ShowFade;
    }

    private void ShowFade()
    {
        _spriteRenderer.enabled = true;
    }
}