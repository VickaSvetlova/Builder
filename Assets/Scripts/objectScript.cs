using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class objectScript : MonoBehaviour {

    private GameObject thisObj;
    private void Awake()
    {

        thisObj = gameObject;
        thisObj.AddComponent<LeanSelectable>();
        //thisObj.AddComponent<LeanSelectableRendererColor>();

       

        thisObj.AddComponent<LeanTranslate>().RequiredFingerCount = 1;     

        thisObj.AddComponent<LeanRotate>().RequiredFingerCount = 2;
        thisObj.GetComponent<LeanRotate>().RotateAxis.y = 1;


        thisObj.AddComponent<LeanScale>().RequiredFingerCount = 2;
        thisObj.GetComponent<LeanScale>().ScaleClamp = true;
        thisObj.GetComponent<LeanScale>().ScaleMin = new Vector3(0.1f, 0.1f, 0.1f);
        thisObj.GetComponent<LeanScale>().ScaleMax = new Vector3(1, 1, 1);

        


    }
    private void Start()
    {
       
    }
}
