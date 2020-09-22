using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
  [SerializeField] private GameObject _endObject;
  [SerializeField] private List<Enemy> _enemys;

  private void End()
  {
    _endObject.SetActive(true);
  }

  private void OnEnable()
  {
    foreach (Enemy elem in _enemys)
    {
      elem.Dying += OnEmeyDying;
    }
  }

  private void OnEmeyDying(Enemy enemy)
  {
    enemy.Dying -= OnEmeyDying;
    _enemys.Remove(enemy);

    if (_enemys.Count == 0)
      End();
  }
}
