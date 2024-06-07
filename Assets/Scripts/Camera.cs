using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target; // The point the camera orbits around
    public float distance = 10.0f; // Initial distance from the target
    public float zoomSpeed = 2.0f;
    public float panSpeed = 0.3f;
    public float rotationSpeed = 3.0f;
    public float verticalSpeed = 5.0f; // Speed of vertical movement

    private float currentX = 0.0f;
    private float currentY = 0.0f;

    void Update()
    {
        // Zoom in and out with the scroll wheel
        distance -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        distance = Mathf.Clamp(distance, 2f, 500f);

        // Orbit around the target when holding the middle mouse button
        if (Input.GetMouseButton(2))
        {
            currentX += Input.GetAxis("Mouse X") * rotationSpeed;
            currentY -= Input.GetAxis("Mouse Y") * rotationSpeed;
            currentY = Mathf.Clamp(currentY, -85f, 85f); // Limit vertical rotation
        }

        // Pan the camera when holding Shift and the middle mouse button
        if (Input.GetMouseButton(2) && Input.GetKey(KeyCode.LeftShift))
        {
            Vector3 right = transform.right;
            Vector3 up = transform.up;

            target.position -= right * Input.GetAxis("Mouse X") * panSpeed;
            target.position -= up * Input.GetAxis("Mouse Y") * panSpeed;
        }

        // Vertical movement with W and S keys
        if (Input.GetKey(KeyCode.W)) target.position += Vector3.up * verticalSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S)) target.position -= Vector3.up * verticalSpeed * Time.deltaTime;

        // Update the camera position and rotation
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 direction = new Vector3(0, 0, -distance);
        transform.position = target.position + rotation * direction;
        transform.LookAt(target);
    }
}