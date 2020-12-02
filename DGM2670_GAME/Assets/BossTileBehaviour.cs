using System.Collections;
using UnityEngine;

public class BossTileBehaviour : MonoBehaviour
{
    public GameObject bossPlatform;
    public GameObject cage;
    public GameObject cage2;

    public bool isSubmerged;

    void OnTriggerEnter(Collider other)
    {
        if (isSubmerged == false && other.gameObject.tag == "Player")
        {
            isSubmerged = true;
            bossPlatform.transform.position = new Vector3(bossPlatform.transform.position.x, bossPlatform.transform.position.y -20, bossPlatform.transform.position.z);
            cage.transform.position = new Vector3(cage.transform.position.x, cage.transform.position.y -20, cage.transform.position.z);
            cage2.transform.position = new Vector3(cage2.transform.position.x, cage2.transform.position.y -20, cage2.transform.position.z);
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
