using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;            // Sun or currently selected planet
    public float distance = 4000f;        // Default distance from target
    public float zoomSpeed = 10f;       // Scroll zoom speed
    public float rotationSpeed = 100f;  // Orbit rotation speed
    public float smoothTime = 0.12f;    // Smooth follow time

    private float currentX = 0f;
    private float currentY = 20f;
    private float minY = -10f;
    private float maxY = 80f;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        // Rotate camera with right-mouse drag
        if (Input.GetMouseButton(1))
        {
            currentX += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            currentY -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
            currentY = Mathf.Clamp(currentY, minY, maxY);
        }

        // Zoom with scroll wheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distance -= scroll * zoomSpeed;
        distance = Mathf.Clamp(distance, 5f, 300f);
    }

    void LateUpdate()
    {
        if (target == null) return;

        // Calculate desired position from spherical coords
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
        Vector3 desiredPos = rotation * negDistance + target.position;

        // Smoothly move the camera
        transform.position = Vector3.SmoothDamp(transform.position, desiredPos, ref velocity, smoothTime);
        transform.LookAt(target.position);
    }
}
