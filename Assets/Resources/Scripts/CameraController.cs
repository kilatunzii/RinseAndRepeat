using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera thirdPersonCamera;
    public Camera topDownCamera;
    private bool isThirdPerson = true;

    void Start()
    {
        // Initialize with the third-person camera active
        thirdPersonCamera.enabled = true;
        topDownCamera.enabled = false;
    }

    void Update()
    {
        // Check for the 'C' key press to toggle the camera view
        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleCamera();
        }
    }

    void ToggleCamera()
    {
        // Toggle the boolean
        isThirdPerson = !isThirdPerson;

        // Enable the appropriate camera based on the current state
        thirdPersonCamera.enabled = isThirdPerson;
        topDownCamera.enabled = !isThirdPerson;
    }
}
