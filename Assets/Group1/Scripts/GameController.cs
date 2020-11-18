using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject blackCurtain;
    [SerializeField]
    private List<Enemy> enemies;

    private void Start()
    {
        foreach (var enemy in enemies)
        {
            enemy.Destroyed += OnEnemyDestroyed;
        }
    }

    private void EndGame()
    {
        blackCurtain.SetActive(true);
    }

    private void OnEnemyDestroyed(Enemy sender)
    {
        enemies.Remove(sender);
        if (enemies.Count == 0)
            EndGame();
    }
}
