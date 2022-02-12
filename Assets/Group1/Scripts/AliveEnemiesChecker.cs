using UnityEngine;
using System.Collections;

public class AliveEnemiesChecker : MonoBehaviour
{
    private const string Enemy = "Enemy";

    private void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(Enemy);

        if (enemies.Length == 0)
        {
            GameController.Controller.FinishGame();
            enabled = false;
        }
    }
}
