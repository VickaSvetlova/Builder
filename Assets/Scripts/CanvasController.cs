using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{

    Camera cam;
    private bool rotateActive = true;
    private void Start()
    {
        cam = Camera.main;
    }

    private void LateUpdate()
    {
        PositionCam();
        if (rotateActive)
        {
            RotationCam();
        }
    }

    private void RotationCam()
    {
        transform.rotation = cam.transform.rotation;
    }
    private void PositionCam()
    {
        transform.position =  cam.transform.position;
    }
}
