using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOnceTriggered : MonoBehaviour
{
    public float delayTime = 1f;
    private WaitForSeconds waitObj;
   
    void Start()
    {
        waitObj = new WaitForSeconds(delayTime);
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        yield return waitObj;
        Destroy(this.gameObject);
    }
}
