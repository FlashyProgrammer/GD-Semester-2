using UnityEngine;

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
        float MouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime;
        float MouseX = Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime;

        xRotation -= MouseY;
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        player.Rotate(Vector3.up * MouseX);
    }
}
