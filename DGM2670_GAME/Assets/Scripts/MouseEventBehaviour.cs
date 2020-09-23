using UnityEngine;
using UnityEngine.Events;

public class MouseEventBehaviour : MonoBehaviour
{
    public UnityEvent mouseDownEvent;

    private void OnMouseDown()
    {
        mouseDownEvent.Invoke();
    }
}
