using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Constroller;
    private const string Message = "SendMEssage";

    [SerializeField] private GameObject _target;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject[] _enemies;

    private void Start()
    {
        Constroller = this;
    }

    public void End()
    {
        _target.SetActive(true);
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
