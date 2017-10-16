using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityStandardAssets.Characters.FirstPerson;

public class TargetController : MonoBehaviour
{
    public UnityEvent FloorDetected;
    Camera cam;
    private RaycastHit hit;
    private bool Hit;
    private string _nameTag = "ground";
    public GameObject _target;
    public GameObject[] objects;
    private float PosNewObject;
    public bool _setObject = true;
    private Color _color = Color.green;
 


    private void Start()
    {
        cam = Camera.main;          
    }
    private void LateUpdate()
    {
       
            if (_setObject)
            {
                if (MultyRayCast(cam.transform.forward, Color.green))
                {
                    _target.active = true;
                    if (hit.transform.tag == _nameTag)
                    {
                        _target.transform.position = new Vector3(hit.point.x, hit.point.y + 0.01f, hit.point.z);
                    }
                    if (Input.GetMouseButtonUp(0))
                    {
                    return;
                        FloorDetected.Invoke();
                        CreateObject();
                    }
                }
                else
                {
                    _target.active = false;
                }
            }
        

    }    

    private bool MultyRayCast(Vector3 dir, Color _color)
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, dir, 1000.0f);
        for (int i = 0; i < hits.Length; i++)
        {
            hit = hits[i];
            Collider Hit = hit.transform.GetComponent<Collider>();
            Debug.DrawRay(transform.position, dir, _color);
            if (Hit)
            {

                return Hit;
            }
        }
        return false;
    }
    public void CreateObject()
    {
        if (_target.active==true)
        {
            if (objects.Length > 0)
            {
                Instantiate(objects[0], new Vector3(_target.transform.position.x, _target.transform.position.y, _target.transform.position.z), Quaternion.identity);
                Debug.Log(PosNewObject);
            }
        }

    }
    private float FindNewPos()
    {
     
        if (MultyRayCast(_target.transform.up, Color.red))
        {
            return PosNewObject = hit.point.y;           
        }
        return 0;
    }
}
