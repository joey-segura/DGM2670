using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[CreateAssetMenu]
public class StringListData : ScriptableObject
{ 
    public List<string> stringList;
    private string returnValue;
    
    public float delayTime = 2f;
    private WaitForSeconds waitObj;
    
    private int i;

    private void OnEnable()
    {
        i = 0;
    }

    public void GetNextString()
    {
        returnValue = stringList[i];
        i = (i + 1) % stringList.Count;
    }

    public void SetTextUIToValue(Text obj)
    {
        obj.text = returnValue;
        Destroy(obj, 5);
    }

    public void InstanceTextBox()
    {
        
    }
}
