using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private float _horizontalInput;
    private float _verticalInput;
    private PlayerMovement _movement;

    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxis(TypedAxis.Horizontal);
        _verticalInput = Input.GetAxis(TypedAxis.Vertical);

        _movement.TryMove(new Vector2(_horizontalInput, _verticalInput));
    }
}
