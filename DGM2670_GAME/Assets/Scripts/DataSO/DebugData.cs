using UnityEngine;

[CreateAssetMenu]
public class DebugData : ScriptableObject
{
    public void OnDebug(string info)
    {
        Debug.Log(info);
    }
    
}
