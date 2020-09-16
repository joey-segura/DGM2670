using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    private Camera cam;
    public Transform pointObj;

    private void Start()
    {
        cam = Camera.main;
    }
    void OnMouseDown()
    {
        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out var hit, 100))
        {
            pointObj.position = hit.point;
        }
    }
}
