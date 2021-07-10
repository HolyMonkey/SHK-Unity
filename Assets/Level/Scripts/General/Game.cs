using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private const string Message = "SendMessage";

    [SerializeField] private GameObject _endObject;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject[] _enemies;

    public void End()
    {
        _endObject.SetActive(true);
    }

    private void Update(){
        foreach (var enemy in _enemies)
        {
            if (enemy == null)
                continue;

                if (Vector3.Distance(_player.gameObject.gameObject.GetComponent<Transform>().position, enemy.gameObject.gameObject.transform.position) < 0.2f)
                {
                    _player.SendMessage(Message, enemy);
                }
        }
    }
}
