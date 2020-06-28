using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class EndGame : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private GameObject _finishSreen;

    public IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }

    private void OnDead()
    {
        var countAliveEnemy = _enemies.Count(enemy => enemy.Alive == true);
        if (countAliveEnemy == 0)
        {
            _finishSreen.SetActive(true);
            StartCoroutine(ReloadScene());
        }
    }

    private void OnEnable()
    {
        foreach (var enemy in _enemies)
            enemy.Dead += OnDead;
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemies)
            enemy.Dead -= OnDead;
    }
}
