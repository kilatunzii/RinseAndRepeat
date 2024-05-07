using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera thirdPersonCamera;
    public Camera topDownCamera;
    private bool isThirdPerson = true;

    void Start()
    {
        //make thirdPerson camera active
        thirdPersonCamera.enabled = true;
        topDownCamera.enabled = false;
    }

    void Update()
    {
        //check for input 'c'  to toggle the camera view
        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleCamera();
        }
    }

    void ToggleCamera()
    {
        //toggle camera
        isThirdPerson = !isThirdPerson;

        //enable appropriate camera
        thirdPersonCamera.enabled = isThirdPerson;
        topDownCamera.enabled = !isThirdPerson;
    }
}
