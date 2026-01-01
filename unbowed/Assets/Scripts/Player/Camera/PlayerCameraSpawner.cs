using UnityEngine;
using Mirror;

public class PlayerCameraSpawner : NetworkBehaviour
{
    public Transform cameraYawAxis;
    public Camera playerCameraPrefab;

    [HideInInspector]
    public Camera playerCameraSpawned;

    public override void OnStartClient()    
    {
        if (!isOwned)
        {
            enabled = false;
            return;
        }

        SpawnCamera();
        DisableOtherCameras();
        EnableCamera();
    }

    void SpawnCamera()
    {
        playerCameraSpawned = Instantiate(playerCameraPrefab, transform);
        playerCameraSpawned.GetComponent<PlayerCameraController>().yawAxis = cameraYawAxis;
    }

    void DisableOtherCameras()
    {
        foreach(Camera camera in FindObjectsByType<Camera>(FindObjectsSortMode.None))
        {
            camera.enabled = false;
        }
    }

    void EnableCamera()
    {
        playerCameraSpawned.enabled = true;
    }
}
