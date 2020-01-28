using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    public Transform target;
    public float targetRotateSpeed;
    private Camera theCamera;

    void Start()
    {
        theCamera = GetComponent<Camera>();
    }

    void Update()
    {
        RotateToMousePosition();
    }

    void RotateToMousePosition()
    {
        // Define the plane that the target is on
        Plane groundPlane;

        groundPlane = new Plane(Vector3.up, target.position);

        //
        float distance;
        Ray theRay = theCamera.ScreenPointToRay(Input.mousePosition);

        /* same as above, but written out
        Ray theRay;
        theRay = new Ray();
        theRay.origin = theCamera.ScreenToWorldPoint(Input.mousePosition);
        theRay.direction = theCamera.transform.forward;
        */

        if (groundPlane.Raycast(theRay, out distance))
        {
            // Find world point where intersection is
            Vector3 intersectionPoint = theRay.GetPoint(distance);

            // Rotate towards that Point
            Quaternion targetRotation;
            Vector3 lookVector = intersectionPoint - target.position;
            targetRotation = Quaternion.LookRotation(lookVector, Vector3.up);

            target.rotation = Quaternion.RotateTowards(target.rotation, targetRotation, targetRotateSpeed * Time.deltaTime);
        }

        // TODO: Rotate towards that Point

        // TEMP TESTING == MOVE SPHERE TO THAT POINT

    }
}
