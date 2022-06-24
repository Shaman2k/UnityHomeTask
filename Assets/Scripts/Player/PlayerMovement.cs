using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxGroundedTimer = 0.2f;
    [SerializeField] private float _jumpHeight = 1.0f;
    [SerializeField] private float _gravityValue = 9.81f;

    private float _verticalVelocity;
    private float _groundedTimer;
    private bool _isGrounded;
    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _isGrounded = _characterController.isGrounded;

        if (_isGrounded)
            _groundedTimer = _maxGroundedTimer;

        if (_groundedTimer > 0)
            _groundedTimer -= Time.deltaTime;

        if (_isGrounded && _verticalVelocity < 0)
            _verticalVelocity = 0f;

        _verticalVelocity -= _gravityValue * Time.deltaTime;
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        moveDirection.y = _verticalVelocity;
        _characterController.Move(transform.TransformDirection(moveDirection) * _speed * Time.deltaTime);
    }

    public void Jump()
    {
        if (_groundedTimer > 0)
        {
            _groundedTimer = 0;
            _verticalVelocity += Mathf.Sqrt(_jumpHeight * _gravityValue);
        }
    }
}

