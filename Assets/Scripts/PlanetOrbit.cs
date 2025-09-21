using UnityEngine;

public class PlanetOrbit : MonoBehaviour
{
    public Transform sun;               // drag the Sun here in Inspector
    public float orbitSpeed = 10f;      // degrees per second (revolution)
    public float selfRotateSpeed = 50f; // planet's own spin
    public float orbitRadius = 10f;     // distance from sun
    public float orbitPhase = 0f;       // starting angle in degrees

    private float angle = 0f;

    void Start()
    {
        angle = orbitPhase;
    }

    void Update()
    {
        angle += orbitSpeed * Time.deltaTime;
        float rad = angle * Mathf.Deg2Rad;

        float x = orbitRadius * Mathf.Cos(rad);
        float z = orbitRadius * Mathf.Sin(rad);

        if (sun != null)
            transform.position = new Vector3(x, 0, z) + sun.position;
        else
            transform.position = new Vector3(x, 0, z);

        // self rotation
        transform.Rotate(Vector3.up * selfRotateSpeed * Time.deltaTime, Space.Self);
    }
}
