using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FadeScreen : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private EnemiesSpawner _enemiesSpawner;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _enemiesSpawner.OnAllEnemiesDied += ShowFade;
    }

    private void ShowFade()
    {
        _spriteRenderer.enabled = true;
        _enemiesSpawner.OnAllEnemiesDied -= ShowFade;
    }
}