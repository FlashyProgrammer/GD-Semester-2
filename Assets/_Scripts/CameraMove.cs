using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float mouseSensitivityX = 50f;
    [SerializeField] private float mouseSensitivityY = 100f;
    [SerializeField] private Transform player;
    private float xRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {

        if (Mouse.current != null) 
        {
            float mouseY = Mouse.current.delta.y.ReadValue() * mouseSensitivityY * Time.deltaTime;
            float mouseX = Mouse.current.delta.x.ReadValue() * mouseSensitivityX * Time.deltaTime;
            xRotation -= mouseY;
            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            player.Rotate(Vector3.up * mouseX);

        }

    }
}
