using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _boostSpeedTime;
    [SerializeField] private float _boostSpeedQuoutinant;
    [SerializeField] private GameObject _menu;
    [SerializeField] private Rigidbody2D _rigidbody;

    public float BoostSpeedTime => _boostSpeedTime;

    private int _killedEnemies = 0;
    private int _startEnemies;

    private void Start()
    {
        _startEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    private void Update()
    {
        _rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    public void PlusKilledEnemies()
    {
        _killedEnemies++;

        if (_killedEnemies >= _startEnemies)
        {
            _menu.SetActive(true);
            enabled = false;
        }
    }

    public IEnumerator BoostSpeed(float workingTime)
    {
        _moveSpeed *= 2;

        yield return new WaitForSeconds(workingTime);

        _moveSpeed /= 2;
    }
}
