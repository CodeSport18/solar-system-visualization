using UnityEngine;

public class SkyboxMovement : MonoBehaviour
{
    public float rotationSpeed = 5f; // adjust in Inspector

    void Update()
    {
        if (RenderSettings.skybox != null)
        {
            // Many Skybox shaders expose "_Rotation" — this works for built-in panoramic/procedural skyboxes
            RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeed);
        }
    }
}
