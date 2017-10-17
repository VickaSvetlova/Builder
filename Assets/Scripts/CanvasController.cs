using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{

    Camera cam;
    private bool rotateActive = true;
    public GameObject menu;
    public GameObject addBooton;
    public TargetController targetController;
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
    public void PressAddKey()
    {
        menu.active = true;
    }
    public void PresEnyModelKey(int numberModel)
    {
        addBooton.active = false;
        menu.active = false;
        targetController._setObject = true;
        targetController.modelNumber = numberModel;
    }
}
