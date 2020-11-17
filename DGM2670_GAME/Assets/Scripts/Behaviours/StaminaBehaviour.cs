using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBehaviour : MonoBehaviour
{
    public Slider staminaBar;

    private int maxStam = 100;
    private int currentStam;

    private int stamDrain = 30;
    private int stamRegain = 10;
    
    public AT_PlayerMoveBehaviour playerMoveScript;
    
    void Start()
    {
        staminaBar.maxValue = maxStam;
        staminaBar.value = maxStam;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            staminaBar.value -= Time.deltaTime * stamDrain;
        }
        else
        {
            staminaBar.value += Time.deltaTime * stamRegain;
        }

        if (staminaBar.value <= 1)
        {
            playerMoveScript.currentSpeed = playerMoveScript.defaultSpeed;
        }
    }
}
