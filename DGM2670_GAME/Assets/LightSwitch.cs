using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    private Light mainLight;
    
    void Start()
    {
        mainLight = GetComponent<Light>();

        mainLight.intensity = 0.5f;
    }
}
