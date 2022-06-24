using UnityEngine;

public class UserInput : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private Player _player;

    private PlayerInput _playerInput;
    private PlayerMovement _playerMovement;
    private MouseLook _mouseLook;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerMovement = GetComponent<PlayerMovement>();
        _mouseLook = GetComponent<MouseLook>();
        _player.GetComponent<Player>();

        _playerInput.FirstPersonMovement.Jump.performed += ctx => _playerMovement.Jump();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Update()
    {
        _playerMovement.ProcessMove(_playerInput.FirstPersonMovement.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        _mouseLook.ProcessLook(_playerInput.FirstPersonMovement.Look.ReadValue<Vector2>());
    }
}
