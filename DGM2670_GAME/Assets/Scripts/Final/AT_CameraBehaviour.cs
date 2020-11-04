using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_CameraBehaviour : MonoBehaviour
{
    public GameObject cameraFocus;
    public float followSpeed = 0.1f;
    public float cameraFOV, fovMAX = 53.0f, fovMIN = 50.0f;
    public float lerpSpeed = 0.1f;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        cameraFocus = GameObject.FindWithTag("Player");
        if (transform.position != cameraFocus.transform.position)
        {
            Vector3 playerPosition = new Vector3(cameraFocus.transform.position.x, cameraFocus.transform.position.y + 16f, cameraFocus.transform.position.z - 16f);
            transform.position = Vector3.Lerp(transform.position, playerPosition, followSpeed);
        }
        
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            print("I'm looking at " + hit.transform.name);

            if (hit.collider.tag != "Player")
            {

            }
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
