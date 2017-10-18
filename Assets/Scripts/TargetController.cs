using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityStandardAssets.Characters.FirstPerson;
using Lean.Touch;

public class TargetController : MonoBehaviour
{
    public UnityEvent FloorDetected;
    private Camera cam;
    private RaycastHit hit;
    private bool Hit;
    private string _nameTag = "ground";
    public GameObject _target;
    public GameObject[] objects;
    private float PosNewObject;
    public bool _setObject { get; set; }
    private Color _color = Color.green;
    public CanvasController canvasController;
    private List<GameObject> clones = new List<GameObject>();
    public float angles=90;

    public int modelNumber { get; set; }

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
                canvasController.text.active = false;
                if (hit.transform.tag == _nameTag)
                {
                    _target.transform.position = new Vector3(hit.point.x, hit.point.y + 0.00001f, hit.point.z);
                }
            }
            else
            {
                _target.active = false;
            }
            if (Input.GetMouseButtonDown(0)|| Input.touchCount == 1)
            {
                FloorDetected.Invoke();
                CreateObject(modelNumber);
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
    public void CreateObject(int numberModel)
    {
        if (_target.active == true && numberModel != null)
        {
            if (objects.Length > 0)
            {
               GameObject  clon = Instantiate(objects[numberModel], new Vector3(_target.transform.position.x, objects[numberModel].GetComponent<Collider>().bounds.extents.y / 2,
                   _target.transform.position.z), Quaternion.AngleAxis(angles, Vector3.right));
               // clon.AddComponent<ScriptAddComponent>();
                clones.Add(clon);

                _setObject = false;
                canvasController.addBooton.active = true;

            }
        }

    }
    private float FindNewPos()
    {

        if (MultyRayCast(_target.transform.up, Color.red))
        {
            return PosNewObject = hit.collider.GetComponent<Renderer>().bounds.size.y / 2;
        }
        return 0;
    }
    public void desatroqAll()
    {
        if (clones.Count > 0)
        {
            foreach(GameObject go in clones)
            {
                Destroy(go);
            }
        }
    }


}
