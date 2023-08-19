using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class InvokeEvent : MonoBehaviour
{
    public UnityEvent Event;
    // Start is called before the first frame update
    void CallEvent()
    {
        Event.Invoke();
    }
}
