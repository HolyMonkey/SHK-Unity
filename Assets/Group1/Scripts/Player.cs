using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void ToAttack(GameObject enemy)
    {
        if (enemy.name == "enemy")
            Destroy(enemy);

        CountEnemies();
    }

    private void Update()
    {
        ToControl(Input.GetButton("Vertical"), Input.GetButton("Horizontal"));
    }

    private void ToControl(bool verticalControl, bool horizontalControl)
    {
        if (verticalControl)
            transform.Translate(0, _speed * Input.GetAxis("Vertical") * Time.deltaTime, 0);

        if (horizontalControl)
            transform.Translate(_speed * Input.GetAxis("Horizontal") * Time.deltaTime, 0, 0);
    }

    private void CountEnemies()
    {
        if (CheckedEnemy.CountEnemies == 0)
        {
            CheckedEnemy.Check.EndGame();
            enabled = false;
        }
    }
}
