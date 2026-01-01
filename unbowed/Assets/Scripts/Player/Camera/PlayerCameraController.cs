using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public float mouseSensitivity;
    public Transform yawAxis;

    private float xRotation;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        BodyRotation();
        CameraRotation();
    }

    void BodyRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity * cam.pixelHeight;
        yawAxis.Rotate(Vector3.up * mouseX);
    }

    void CameraRotation()
    {
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity * cam.pixelHeight;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -89.9f, 89.9f);
        
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
