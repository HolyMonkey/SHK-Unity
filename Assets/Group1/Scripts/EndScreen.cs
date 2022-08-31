using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private GameObject _endScreen;

    private void OnEnable()
    {
        GameController.EndGame += End;
    }
    private void OnDisable()
    {
        GameController.EndGame -= End;
    }

    private void End()
    {
        _endScreen.SetActive(true);
    }
}



