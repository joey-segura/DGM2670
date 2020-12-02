using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class BossTileBehaviour : MonoBehaviour
{
    public GameObject bossPlatform;
    public GameObject cage;

    public bool isSubmerged;

    void OnTriggerEnter(Collider other)
    {
        if (isSubmerged == false)
        {
            Debug.Log("BOSS TRIGGERED");
            isSubmerged = true;
            bossPlatform.transform.position = new Vector3(bossPlatform.transform.position.x, bossPlatform.transform.position.y -20, bossPlatform.transform.position.z);
            cage.transform.position = new Vector3(cage.transform.position.x, cage.transform.position.y -20, cage.transform.position.z);
            StartCoroutine(Recharge());
        }
    }

    IEnumerator Recharge()
    {
        yield return new WaitForSeconds(15);
        bossPlatform.transform.position = new Vector3(bossPlatform.transform.position.x, bossPlatform.transform.position.y +20, bossPlatform.transform.position.z);
        isSubmerged = false;
    }
}
