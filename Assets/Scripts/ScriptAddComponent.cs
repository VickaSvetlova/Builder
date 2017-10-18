using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

[RequireComponent(typeof(LeanSelectable))]
[RequireComponent(typeof(LeanSelectableRendererColor))]
[RequireComponent(typeof(LeanRotate))]
[RequireComponent(typeof(LeanTranslate))]
[RequireComponent(typeof(LeanScale))]
[RequireComponent(typeof(Rigidbody))]
public class ScriptAddComponent : MonoBehaviour
{
    GameObject thisObj;
    private void Start()
    {


        thisObj = gameObject;

        thisObj.GetComponent<LeanTranslate>().RequiredFingerCount = 1;

        thisObj.GetComponent<Rigidbody>().freezeRotation = true;
        thisObj.GetComponent<LeanRotate>().RequiredFingerCount = 2;
        thisObj.GetComponent<LeanRotate>().RotateAxis.z = 1;
        thisObj.GetComponent<LeanRotate>().RotateAxis.y = 0;


        thisObj.GetComponent<LeanScale>().RequiredFingerCount = 2;
        thisObj.GetComponent<LeanScale>().ScaleClamp = true;
        thisObj.GetComponent<LeanScale>().ScaleMin = new Vector3(0.1f, 0.1f, 0.1f);
        thisObj.GetComponent<LeanScale>().ScaleMax = thisObj.GetComponent<Transform>().transform.localScale;

        //thisObj.GetComponent<LeanSelectable>().OnSelect = new LeanSelectable.LeanFingerEvent();
    }
    public void gravity(bool offOn)
    {
        thisObj.GetComponent<Rigidbody>().useGravity = offOn;
    }
}
