using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private float _speed = 5;
   
    private void Update()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        transform.position += moveDirection.normalized * _speed * Time.deltaTime;
    } 
}
