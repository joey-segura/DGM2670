using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_CameraBehaviour : MonoBehaviour
{
    public GameObject cameraFocus;
    public float followSpeed = 0.1f;
    public float cameraFOV, fovStart = 20f, fovMAX = 53.0f, fovMIN = 50.0f;
    public float lerpSpeed = 0.1f;


    void Start()
    {
        cameraFocus = GameObject.Find("Humanoid_01");
        //Camera.main.fieldOfView = fovStart;
    }

   
    void LateUpdate()
    {
        //Start zoomed close and slowly expand as player walks around.
        
        //if (Input.anyKey && Camera.main.fieldOfView <= fovMIN)
        {
            //Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView,fovMAX,Time.deltaTime / lerpSpeed);
        }
        
        if (transform.position != cameraFocus.transform.position)
        {
            Vector3 playerPosition = new Vector3(cameraFocus.transform.position.x, cameraFocus.transform.position.y + 14f, cameraFocus.transform.position.z - 14f);
            transform.position = Vector3.Lerp(transform.position, playerPosition, followSpeed);
        }
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView,fovMAX,Time.deltaTime / lerpSpeed);
        }
        else
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView,fovMIN,Time.deltaTime / lerpSpeed);
        }
    }
}
