using System.Collections;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
  [SerializeField] private float _speed = 4;
  [SerializeField] private bool _isTimeSpeedUp;
  [SerializeField] private float _fastSpeedTime = 2f;
  [SerializeField] private float _SpeedDown = 2f;
  [SerializeField] private float _speedDown = 2f;
  [SerializeField] private float _speedUp = 2f;

  private void Start()
  {
    if (_isTimeSpeedUp)
        StartCoroutine(SetPlayerMoveFaster());
  }

  private void Update()
  {
    float vertical = Input.GetAxis("Vertical") * _speed * Time.deltaTime;
    float horizontal = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;

    transform.Translate(horizontal, vertical, 0);
  }

  public void ReceiveMessage(GameObject elem)
  {
    if (elem.GetComponent<Speed>() != null)
      StartCoroutine(SetPlayerMoveFaster());

  }

  private IEnumerator SetPlayerMoveFaster()
  {
    float elapsedTime = _fastSpeedTime;
    _speed *= _speedUp;

    while (elapsedTime > 0)
    {
      elapsedTime -= Time.deltaTime;
      yield return null;
    }

    _speed /= _speedDown;
  }
}
