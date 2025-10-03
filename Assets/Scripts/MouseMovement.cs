using UnityEngine;

public class MouseMovement : MonoBehaviour
{

    public float mouseSens = 100f;

    float xRotation = 0f;
    float yRotation = 0f;

    public float topClamp = -90f;
    public float bottomClamp = 90f;

    void Start()
    {
        // Lock Cursor and Hide Cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Receive mouse inputs
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        // Looking up and down (x-axis)
        xRotation -= mouseY;

        // Clamp rotation
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);

        // Looking left and right (y-axis)
        yRotation += mouseX;

        // Apply rotations to body
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
