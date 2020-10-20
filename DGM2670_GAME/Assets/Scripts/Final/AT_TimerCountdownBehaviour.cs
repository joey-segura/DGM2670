using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AT_TimerCountdownBehaviour : MonoBehaviour
{
    public Transform tubeLocation;
    public GameObject rollingLog;
    
    public int timerTime = 10;
    public Text timerDisplay;

    void Start()
    {
        StartCoroutine(TimerCountDown());
    }
    
    IEnumerator TimerCountDown()
    {
        while (timerTime > 0)
        {
            timerDisplay.text = timerTime.ToString();
            
            yield return new WaitForSeconds(1f);

            timerTime--;
            if (timerTime == 3)
            {
                GameObject rollingLogClone = (GameObject)Instantiate(rollingLog, tubeLocation.position, tubeLocation.rotation);
                Destroy (rollingLogClone, 40.0f);
            }
            if (timerTime == 0)
            {
                timerTime = 10;
            }
        }
    }
}
