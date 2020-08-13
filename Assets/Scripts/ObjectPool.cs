using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<GameObject> _pool = new List<GameObject>();


    protected void Initialized(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(true);
            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject[] result)
    {
        GameObject[] container = new GameObject[_pool.Count];
        for (int i = 0; i < _pool.Count; i++)
        {
            container[i] = _pool[i];
        }
        result = container;
        return result != null;
    }

    public void ResetPool()
    {
        foreach (var item in _pool)
        {
            item.SetActive(true);
        }
    }
}
