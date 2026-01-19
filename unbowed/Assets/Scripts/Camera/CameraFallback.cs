using UnityEngine;

public class CameraFallback : MonoBehaviour
{
    void Update()
    {
        if (Camera.main == null)
        {
            Camera[] cameras = FindObjectsByType<Camera>(FindObjectsSortMode.None);

            if (cameras.Length == 1)
            {
                cameras[0].enabled = true;
            }
        }
    }
}
