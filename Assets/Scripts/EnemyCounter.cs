using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] private GameObject _winScreen;

    private List<Enemy> _enemies = new List<Enemy>();

    public void EnemyAdd(Enemy enemy)
    {
        _enemies.Add(enemy);
    }

    public void EnemyDown(Enemy enemy)
    {
        _enemies.Remove(enemy);

        if (_enemies.Count == 0)
            End();
    }

    private void End()
    {
        _winScreen.SetActive(true);
    }
}
