using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountdownBehaviour : MonoBehaviour
{
    public int timerTime = 4;
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

            if (timerTime == 0)
            {
                timerTime = 5;
            }
        }
    }
}
