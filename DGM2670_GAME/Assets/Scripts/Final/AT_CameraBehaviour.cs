using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_CameraBehaviour : MonoBehaviour
{
    public GameObject cameraFocus;
    public float followSpeed = 0.1f;
    public float cameraFOV;


    void Start()
    {
        cameraFocus = GameObject.Find("Humanoid_01");
        cameraFOV = 60.0f;
    }

   
    void LateUpdate()
    {
        Camera.main.fieldOfView = cameraFOV;
        
        if (transform.position != cameraFocus.transform.position)
        {
            Vector3 playerPosition = new Vector3(cameraFocus.transform.position.x, cameraFocus.transform.position.y + 12f, cameraFocus.transform.position.z - 12f);
            transform.position = Vector3.Lerp(transform.position, playerPosition, followSpeed);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            cameraFOV = 65.0f;
        }
        else
        {
            cameraFOV = 60.0f;
        }
    }
}
