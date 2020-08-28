using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMove : MonoBehaviour
{
    public CharacterController cntrl;
    public Transform cam;
    public Camera cam2;

    public float spd = 8f;
    public float smoothTime = 0.1f;
    private float turnVelocity;
    
    void Start()
    {
        cam2 = FindObjectOfType<Camera>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        //Look at mouse position
        Ray cameraRay = cam2.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 focusPoint = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, focusPoint, Color.red);
            transform.LookAt(focusPoint);
        }
        
        
       
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z)*Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            cntrl.Move(moveDirection.normalized * spd * Time.deltaTime);
        }
    }
}
