using UnityEngine;
using UnityEngine.UI;

public class CamScoreBehaviour : MonoBehaviour
{
    public Text camText;
    public static int camAmt;
    
    void Start()
    {
        camAmt = 0;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            camAmt = camAmt + 1;
            camText.text = camAmt.ToString();
            Destroy(this.gameObject);
        }
    }
}
