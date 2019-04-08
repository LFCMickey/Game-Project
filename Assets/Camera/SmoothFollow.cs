using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour
{

    public bool shouldRotate = true;

    // The target we are following
    public Transform target;
    // The distance in the x-z plane to the target
    public float distance = 10.0f;
    // the height we want the camera to be above the target
    public float height = 5.0f;
    // How much we
    // The vertical input from input devices.
    private float vertical;
    // The horizontal input from input devices.
    private float horizontal;
    public float rotationSpeed = 2f;
    public float MaxHeight = 1.0f;
    public float LowHeight = 0f;
    public float ScrollIncrement = 0.5f;
    public float heightDamping = 2.0f;
    public float rotationDamping = 3.0f;
    float wantedRotationAngle;
    float wantedHeight;
    float currentRotationAngle;
    float currentHeight;
    Quaternion currentRotation;


    void LateUpdate()
    {
        if (target)
        {
                //Moves the Camera Forward and back on scroll
                if (Input.GetAxis("Mouse ScrollWheel") > 0 && Camera.main.orthographicSize > 1)
            {
                if (LowHeight <= height)
                    height -= ScrollIncrement;
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0 && Camera.main.orthographicSize > 1)
            {
                    if (MaxHeight >= height)
                        height += ScrollIncrement;
            }
                // Calculate the current rotation angles
                wantedRotationAngle = target.eulerAngles.y;
                wantedHeight = target.position.y + height;
                currentRotationAngle = transform.eulerAngles.y;
                currentHeight = transform.position.y;
                // Damp the rotation around the y-axis
                currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
                // Damp the height
                currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
                // Convert the angle into a rotation
                currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);
                // Set the position of the camera on the x-z plane to:
                // distance meters behind the target
                transform.position = target.position;
                transform.position -= currentRotation * Vector3.forward * distance;
                // Set the height of the camera
                transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);
                // Always look at the target
                if (shouldRotate)
                    transform.LookAt(target);
            }
    }
}