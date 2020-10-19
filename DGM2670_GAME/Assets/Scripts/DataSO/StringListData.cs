using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[CreateAssetMenu]
public class StringListData : ScriptableObject
{ 
    public List<string> stringList;
    private string returnValue;
    
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
    }
}
