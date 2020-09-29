using UnityEngine;
using UnityEngine.Events;

public class MonoEventsBehaviour : MonoBehaviour
{

    public UnityEvent startEvent, onEnableEvent;

    private void Start()
    {
        startEvent.Invoke();
    }

    public void OnEnable()
    {
        onEnableEvent.Invoke();
    }
        
}
