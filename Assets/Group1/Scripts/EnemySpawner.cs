using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Enemy _template;
    [SerializeField] private Player _player;
    [SerializeField] private int _startCount;
    [SerializeField] private int _enemiesLeft;

    private List<Enemy> _enemies;

    public event UnityAction AllEnemiesLeft;

    private void Awake()
    {
        _enemies = new List<Enemy>();

        for(int i = 0; i < _startCount; i++)
        {
            var template = Instantiate(_template, _container);
            _enemies.Add(template);
        }
    }

    private void Update()
    {
        foreach (var enemy in _enemies)
        {
            if (Vector3.Distance(_player.transform.position, enemy.transform.position) < _player.CheckRadius && enemy.gameObject.activeSelf)
            {
                StartCoroutine(DeactivateByTimer(enemy));
                _enemiesLeft--;

                if (_enemiesLeft <= 0)
                {
                    AllEnemiesLeft?.Invoke();
                }
            }
        }
    }

    private IEnumerator DeactivateByTimer(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);

        yield return new WaitForSeconds(2f);

        enemy.gameObject.SetActive(true);
    }
}
