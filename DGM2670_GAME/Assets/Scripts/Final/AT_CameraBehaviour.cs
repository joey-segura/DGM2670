using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_CameraBehaviour : MonoBehaviour
{
    public GameObject cameraFocus;
    public float followSpeed = 0.1f;


    void Start()
    {
        cameraFocus = GameObject.Find("Humanoid_01");
    }

   
    void LateUpdate()
    {
        if (transform.position != cameraFocus.transform.position)
        {
            Vector3 playerPosition = new Vector3(cameraFocus.transform.position.x, cameraFocus.transform.position.y + 12f, cameraFocus.transform.position.z - 12f);
            transform.position = Vector3.Lerp(transform.position, playerPosition, followSpeed);
        }
    }
}
