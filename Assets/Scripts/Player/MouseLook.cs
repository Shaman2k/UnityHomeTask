using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _xSensivity;
    [SerializeField] private float _ySensivity;

    private float _xRotation = 0f;
    private CharacterController _characterController;
    private float _clamp = 80f;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        _xRotation -= mouseY * Time.deltaTime * _ySensivity;
        _xRotation = Mathf.Clamp(_xRotation, -_clamp, _clamp);
        _camera.transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        _characterController.transform.Rotate(Vector3.up * mouseX * _xSensivity * Time.deltaTime);
    }
}
   