using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TargetController : MonoBehaviour
{
    public UnityEvent FloorDetected;
    Camera cam;
    private RaycastHit hit;
    private bool Hit;
    public GameObject _target;
    public GameObject[] objects;


    private void Start()
    {
        cam = Camera.main;
    }
    private void LateUpdate()
    {
        if (MultyRayCast(cam.transform.forward))
        {

            if (hit.collider.tag == "ground")
            {
                _target.transform.position = new Vector3(hit.point.x, hit.point.y + 0.01f, hit.point.z);
            }
            if (Input.GetMouseButtonUp(0))
            {
                FloorDetected.Invoke();
                CreateObject();
            }
        }

    }

    private bool RayCaster()
    {
        Vector3 forward = Camera.main.transform.TransformDirection(Vector3.forward) * 100;
        Debug.DrawRay(Camera.main.transform.position, forward, Color.green);
        Hit = Physics.Raycast(Camera.main.transform.position, (forward), out hit);
        return Hit;
    }
    private bool MultyRayCast(Vector3 dir)
    {

        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, dir, 100.0f);
        for (int i = 0; i < hits.Length; i++)
        {
            hit = hits[i];
            Collider Hit = hit.transform.GetComponent<Collider>();
            Debug.DrawRay(transform.position, dir, Color.green);
            if (Hit)
            {
                if (hit.collider.tag == "ground")
                {
                    return Hit;
                }
            }
        }
        return false;
    }
    private void CreateObject()
    {
        if (objects.Length > 0)
        {
            Instantiate(objects[0], _target.transform.position, Quaternion.identity);
        }

    }
}
