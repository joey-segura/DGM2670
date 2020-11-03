using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class GameActionData : ScriptableObject
{
    public UnityAction action;

    public void Raise()
    {
        action?.Invoke();
    }
}
